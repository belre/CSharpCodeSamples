using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IniFileReflection
{
  public class IniFormatFile
  {

    [AttributeUsage(AttributeTargets.Property)]
    protected class SectionAttribute : Attribute
    {
      private string[] _label;
      private ReadingFormatStatus _status;

      public SectionAttribute()
      {
      }

      public SectionAttribute(string label, ReadingFormatStatus status)
        : this(new string[] { label }, status)
      {
      }

      public SectionAttribute(string[] label_import_candidates, ReadingFormatStatus status)
      {
        _label = label_import_candidates;
        _status = status;
      }

      public string[] GivenLabel
      {
        get
        {
          return _label;
        }
      }

      public ReadingFormatStatus NextStatus
      {
        get
        {
          return _status;
        }
      }
    }

    [AttributeUsage(AttributeTargets.Property)]
    internal class IniParamAttribute : Attribute
    {
      private string _label;
      private bool _changed_start_index;
      private int _start_index;

      public IniParamAttribute()
      {
      }

      public IniParamAttribute(string label)
      {
        _label = label;
      }

      public IniParamAttribute(string label, int start_index)
      {
        _label = label;
        _changed_start_index = true;
        _start_index = start_index;
      }
      public string GivenLabel
      {
        get
        {
          return _label;
        }
      }

      public int StartIndex
      {
        get
        {
          return _changed_start_index ? _start_index : 0;
        }
      }
    }

    protected enum ReadingFormatStatus
    {
      BeginOfFile,
      SingleSectionFormat,        // [...]
      IniParamFormat,       // Label=Value
      EndOfFile
    };



    protected virtual Regex IniParamRegex
    {
      get
      {
        return new Regex(@"(\w+)\=([\s]*.+)");
      }
    }

    protected Dictionary<ReadingFormatStatus, Regex> FormatRegex
    {
      get
      {
        var dict = new Dictionary<ReadingFormatStatus, Regex>();
        dict[ReadingFormatStatus.SingleSectionFormat] = new Regex(@"\[(\w+)\]");
        dict[ReadingFormatStatus.IniParamFormat] = IniParamRegex;

        return dict;
      }
    }

    /// <summary>
    /// 現在のiniファイルの状態から、次に遷移可能な状態を表す.
    /// IEnumerableの順序は、優先度を表す.
    /// 例えば、 ReadingFormatStatus.IniParamFormat, ReadingFormatStatus.SectionFormatとなっていれば、
    /// IniParamFormatを先に検出し、それが検出されない場合はSectionFormatにより検出する.
    /// </summary>
    protected virtual Dictionary<ReadingFormatStatus, IEnumerable<ReadingFormatStatus>> NextAvailableStatus
    {
      get
      {
        var dict = new Dictionary<ReadingFormatStatus, IEnumerable<ReadingFormatStatus>>();

        dict[ReadingFormatStatus.BeginOfFile] = new List<ReadingFormatStatus>()
        {
          ReadingFormatStatus.SingleSectionFormat, ReadingFormatStatus.IniParamFormat
        };

        dict[ReadingFormatStatus.SingleSectionFormat] = new List<ReadingFormatStatus>()
        {
          ReadingFormatStatus.IniParamFormat
        };
        dict[ReadingFormatStatus.IniParamFormat] = new List<ReadingFormatStatus>()
        {
          ReadingFormatStatus.IniParamFormat, ReadingFormatStatus.SingleSectionFormat
        };
        
        return dict;
      }
    }

    /// <summary>
    /// 最初来るべきデータを表す。
    /// - BeginOfFileを指定した場合、[...]のセクションを読み取ってデータ詳細を読み取る
    /// - それ以外を指定する場合は、FirstStatusと同じデータを読み続ける(標準データ、連動テーブルなど)
    /// </summary>
    protected virtual ReadingFormatStatus FirstStatus
    {
      get
      {
        return ReadingFormatStatus.BeginOfFile;
      }
    }

    protected virtual IEnumerable<ReadingFormatStatus> ReadCheckStatusList
    {
      get
      {
        if (FirstStatus == ReadingFormatStatus.BeginOfFile)
        {
          return new[]
          {
            ReadingFormatStatus.IniParamFormat,
          };
        }
        else if (FirstStatus == ReadingFormatStatus.IniParamFormat )
        {
          return new List<ReadingFormatStatus>();
        }
        else
        {
          throw new InvalidOperationException();
        }
      }
    }

    protected virtual IEnumerable<PropertyInfo> Sections
    {
      get;
    }

    /// <summary>
    /// 読み取りに使用するIni形式のファイルフォーマットのプロパティを表します.
    /// ※ オーバーライドにより、各種ファイルフォーマットで独自のパラメータを持たせられます.
    /// </summary>
    protected virtual IEnumerable<PropertyInfo> ConditionParams
    {
      get => new List<PropertyInfo>();
    }

    private List<PropertyInfo> _performed_condition_params;

    /// <summary>
    /// ファイルの読み込みで読み取ることが出来たプロパティを表します。
    /// </summary>
    protected virtual IEnumerable<PropertyInfo> PerformedConditionParams
    {
      get => _performed_condition_params;
    }




    /// <summary>
    /// エンコード情報を表します.
    /// </summary>
    [IniParam]
    public virtual string SaveEncoding
    {
      get;
      set;
    }

    /// <summary>
    /// 言語情報を表します.
    /// </summary>
    [IniParam]
    public virtual string SaveLanguage
    {
      get;
      set;
    }

    protected virtual void NotifyAfter(ReadingFormatStatus status)
    {

    }

    private bool _is_tab_table_read = false;

    protected virtual void InitTabTable()
    {

    }

    /// <summary>
    /// データインポート時に読み取る処理を表す.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="encoding"></param>
    /// <param name="default_culture"></param>
    public virtual void ReadFromText(string text, Encoding encoding, CultureInfo default_culture)
    {

      _performed_condition_params = new List<PropertyInfo>();

      // "\n"が含まれている場合
      // "\r\n"に変換する
      text = text.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);


      // 読み取ったファイルパスを指定する
      var source_array = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
      var current_format_status = FirstStatus;

      // 各ラインを読みとり
      IniFormatFile root_ini_file = this;
      var passing_status_list = new List<ReadingFormatStatus>();

      int text_index = 0;
      foreach (var source_line in source_array)
      {

        if (text_index == source_array.Length - 1)
        {
          // 最後のデータで空行だった場合は読み込まない(どのデータでも)
          if (source_line == string.Empty)
          {
            continue;
          }
        }

        // 遷移可能な状態の一覧を取得
        var available_status = NextAvailableStatus[current_format_status];

        // 正規表現に合うステータスの取得
        MatchCollection matched = null;
        ReadingFormatStatus matched_status = ReadingFormatStatus.SingleSectionFormat;
        foreach (var seek_status in available_status)
        {
          var match = FormatRegex[seek_status].Matches(source_line);
          if (match.Count != 0)
          {
            matched = match;
            matched_status = seek_status;
            break;
          }
        }

        

        // データの解読
        if (matched_status == ReadingFormatStatus.SingleSectionFormat)
        {
          if (root_ini_file != null)
          {
            // 読み取ることが出来たConditionを受け渡す
            root_ini_file.GivePerformedConditionProperties(_performed_condition_params);

            // Section Endを通知する
            root_ini_file.CompleteSectionEnd();

            // セクションを読み取った後に
            // ファイルが行なう処理を記述する
            NotifyAfter(current_format_status);
          }

          var label_line = matched[0].Groups[1].Value;

          foreach (var section in Sections)
          {
            // リフレクションでattributeを取得
            var attr = (SectionAttribute)section.GetCustomAttribute(typeof(SectionAttribute));

            // attributeからラベル名を取得
            var label_name_list = new string[] { section.Name };
            if (attr != null && attr.GivenLabel != null)
            {
              label_name_list = attr.GivenLabel;
            }

            // labelと一致しているかの確認
            foreach (var label in label_name_list)
            {
              if (label_line.Equals(label))
              {
                // 現在のオブジェクトから派生しているSectionのデータを取得する
                // 従って、この読み取りで実行できる階層のデータは１階層のみである(再帰できない)
                // だがインポートフィルタも含めて多階層のデータは現状存在しないので、
                // 一旦そのままで良いと思われる
                root_ini_file = (IniFormatFile)section.GetValue(this);
                current_format_status = attr.NextStatus;
                if (!passing_status_list.Contains(current_format_status))
                {
                  passing_status_list.Add(current_format_status);
                }
                break;
              }
            }
          }
        }
        else if (matched_status == ReadingFormatStatus.IniParamFormat)
        {
          var label_line = matched[0].Groups[1].Value;
          var value_line = matched[0].Groups[2].Value;

          foreach (var ini_param in root_ini_file.ConditionParams)
          {
            if (ini_param == null)
            {
              continue;
            }

            // リフレクションでattributeを取得
            var attr = (IniParamAttribute)ini_param.GetCustomAttribute(typeof(IniParamAttribute));

            // attributeからラベル名を取得
            var label_name = ini_param.Name;
            if (attr != null && attr.GivenLabel != null)
            {
              label_name = attr.GivenLabel;
            }

            // labelと一致しているかの確認
            if (label_line.Equals(label_name))
            {
              // 完全一致
              // 型によって入力方法を指定
              {

                if (ini_param.PropertyType == typeof(decimal))
                {
                  decimal val = decimal.Parse(value_line);
                  ini_param.SetValue(root_ini_file, val);
                }
                else if (ini_param.PropertyType == typeof(bool))
                {
                  int val = int.Parse(value_line);
                  ini_param.SetValue(root_ini_file, val != 0);
                }
                else if (ini_param.PropertyType == typeof(int))
                {
                  int val = int.Parse(value_line);
                  ini_param.SetValue(root_ini_file, val);
                }
                else if (ini_param.PropertyType.IsEnum)
                {
                  var val = Enum.Parse(ini_param.PropertyType, value_line);
                  if (Enum.IsDefined(ini_param.PropertyType, val))
                  {
                    ini_param.SetValue(root_ini_file, val);
                  }
                }
                else
                {
                  ini_param.SetValue(root_ini_file, value_line);
                }

                _performed_condition_params.Add(ini_param);
              }


              // 一致していれば次の行に移動する
              break;
            }
            else if (label_name.Contains("#"))
            {
              // ラベルに#を含む場合は数字との一致を確認
              var regex = new Regex($@"{label_name.Replace("#", string.Empty)}(\d+)");
              var match_result = regex.Match(label_line);
              if (match_result.Success && match_result.Groups.Count >= 2)
              {
                {
                  int index = int.Parse(match_result.Groups[1].Value);
                  if (ini_param.PropertyType == typeof(decimal[]))
                  {
                    var array_object = (decimal[])ini_param.GetValue(root_ini_file);
                    array_object[index] = decimal.Parse(value_line);
                  }

                  else if (ini_param.PropertyType == typeof(int[]))
                  {
                    var array_object = (int[])ini_param.GetValue(root_ini_file);
                    array_object[index] = int.Parse(value_line);
                  }
                  else if (ini_param.PropertyType == typeof(bool[]))
                  {
                    var array_object = (bool[])ini_param.GetValue(root_ini_file);
                    array_object[index] = int.Parse(value_line) != 0;
                  }
                  else if (ini_param.PropertyType.IsArray && ini_param.PropertyType.GetElementType().IsEnum)
                  {
                    var array_object = (Array)ini_param.GetValue(root_ini_file);
                    var enum_value = (Enum)Enum.Parse(ini_param.PropertyType.GetElementType(), value_line);

                    if (Enum.IsDefined(ini_param.PropertyType.GetElementType(), enum_value))
                    {
                      array_object.SetValue((Enum)Enum.Parse(ini_param.PropertyType.GetElementType(), value_line), index);
                    }
                  }

                  _performed_condition_params.Add(ini_param);
                }
              }
            }
          }
        }

        text_index++;
      }


      // データ終了扱い
      if (root_ini_file != null)
      {
        root_ini_file.CompleteSectionEnd();
      }

      NotifyAfter(ReadingFormatStatus.EndOfFile);
    }




    /// <summary>
    /// iniファイルのSectionブロックの名前の取得
    /// </summary>
    /// <param name="section_property"></param>
    /// <returns></returns>
    protected virtual string GetSectionName(PropertyInfo section_property)
    {
      var attr = (SectionAttribute)section_property.GetCustomAttribute(typeof(SectionAttribute));
      var name = attr.GivenLabel.First();
      return name;
    }

    /// <summary>
    /// データエキスポート時に、Conditionの部分をテキストとして出力する処理を表す.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="builder"></param>
    /// <param name="encoding"></param>
    /// <param name="export_culture"></param>
    public virtual void ExportConditionText(StringBuilder builder, Encoding encoding, CultureInfo export_culture)
    {
      SaveLanguage = export_culture.Name;
      SaveEncoding = encoding.WebName;

      // ini形式のデータ
      if (ConditionParams != null)
      {
        foreach (var condition in ConditionParams)
        {
          if (condition == null)
          {
            continue;
          }

          // リフレクションでattributeを取得
          var attr = (IniParamAttribute)condition.GetCustomAttribute(typeof(IniParamAttribute));

          // attributeからラベル名を取得
          var label_name = condition.Name;
          if (attr != null && attr.GivenLabel != null)
          {
            label_name = attr.GivenLabel;
          }

          int auto_allocator_digit = 0;
          string replace_pattern = null;
          var output_values = new List<object>();
          if (condition.PropertyType.IsArray)
          {
            // 配列で定義されたプロパティの場合.
            var array_value = (Array)condition.GetValue(this);
            if (array_value.Length < 1)
            {
              continue;
            }

            // データを配列ごと参照する。
            var array_type = array_value.GetValue(0).GetType();
            for (int i = 0; i < array_value.Length; i++)
            {
              output_values.Add(array_value.GetValue(i));
            }

            // 名前が～～～##という形で割り当てられたときのみ有効として、
            // 有効な場合は桁数を返却する
            var regex = new Regex($@"(\#+)");
            var match_result = regex.Match(label_name);
            if (match_result.Success && match_result.Groups.Count >= 2)
            {
              auto_allocator_digit = match_result.Groups[1].Length;
              replace_pattern = new string('#', auto_allocator_digit);
            }
            else
            {
              continue;
            }
          }
          else
          {
            // 配列で定義されていないプロパティの場合、
            // 単独の値のみを参照する。
            output_values.Add(condition.GetValue(this));
          }

          // データとして書き込み
          for (int i = 0; i < output_values.Count; i++)
          {
            // Attributeに書かれている内容で、
            // StartIndex未満の場合は、
            // データに書き込まない
            if (i < attr.StartIndex)
            {
              continue;
            }

            // ラベル名を整形
            var format_label = label_name;
            if (replace_pattern != null)
            {
              format_label = format_label.Replace(replace_pattern, i.ToString($"D{auto_allocator_digit}"));
            }

            // 値取得(List型として格納済み)
            var value = output_values[i];

            // 値変換して書き込み
            if (value == null)
            {
              builder.AppendLine($"{format_label}={string.Empty}");
            }
            else if (value.GetType().IsEnum)
            {
              builder.AppendLine($"{format_label}={(int)value}");
            }
            else if (value is bool)
            {
              int val = (bool)value ? 1 : 0;
              builder.AppendLine($"{format_label}={val}");
            }
            else
            {
              builder.AppendLine($"{format_label}={value}");
            }
          }
        }
      }
    }


    protected virtual void CompleteSectionEnd()
    {

    }

    protected virtual void GivePerformedConditionProperties(IEnumerable<PropertyInfo> properties)
    {

    }


  }
}
