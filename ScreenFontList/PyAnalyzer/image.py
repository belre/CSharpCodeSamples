import cv2
import numpy as np
from typing import Dict, Tuple, List, Optional, Any, Sequence
from file_io import FileIo
import shutil

class SourceImage:
    name: str
    img: Any

    def read(self, root_dir: str, target_file: str, margin:int=0):
        self.name = target_file
        
        # 一時的な英数字のファイル名
        temp_path = 'temp_image.png'

        # ファイルをコピー
        shutil.copy(f"{root_dir}/{target_file}", temp_path)
        
        self.img = cv2.imread(temp_path,  cv2.IMREAD_UNCHANGED )           
        self.raw_img = cv2.imread(temp_path, cv2.IMREAD_UNCHANGED )
        

    def write(self, root_dir: str, target_file: str):
        cv2.imwrite(f"{root_dir}/{target_file}.png", self.img, [cv2.IMWRITE_PNG_COMPRESSION, 0])
        
class FontPatternMatchingResult:
    pattern_matching_similarity: float
    histogram_similarity: float
    matching_top_left: Sequence[int]
    matching_bottom_right: Sequence[int]
    target: str



class FontPatternMatchingImageSet:
    reference_source: SourceImage
    target_source: SourceImage
    matching_source: SourceImage = None
    matching_result: FontPatternMatchingResult
    pattern_matching_similarity: float
    histogram_similarity: float
    matching_top_left: Sequence[int]
    matching_bottom_right: Sequence[int]
    
    def read(self, file_io: FileIo):
        self.reference_source = SourceImage()
        self.reference_source.read(file_io.root_dir, file_io.reference_file)

        self.target_source = SourceImage()
        self.target_source.read(file_io.root_dir, file_io.target_file, margin=self.reference_source.img.shape[0] / 2) 

    def imread_with_custom_margin(self, source: SourceImage, top=10, bottom=10, left=10, right=10, color=0):
        img = source.img
        
        # 新しいサイズでキャンバス作成
        new_height = img.shape[0] + top + bottom
        new_width = img.shape[1] + left + right
        
        # 指定色で塗りつぶし
        canvas = np.full((new_height, new_width, 4), color, dtype=img.dtype)
        
        # 元画像を中央に配置
        canvas[top:top+img.shape[0], left:left+img.shape[1],:] = img
        
        return canvas

    def matching(self):
        w_half = int(self.reference_source.img.shape[1] /2)
        h_half = int(self.reference_source.img.shape[0] /2)
        target_cloned_source = self.imread_with_custom_margin(self.target_source, top=h_half, bottom=h_half, left=w_half, right=w_half)
        try:
            result = cv2.matchTemplate(target_cloned_source, self.reference_source.img, cv2.TM_CCOEFF_NORMED)
        except:
            return
        min_val, max_val, min_loc, max_loc = cv2.minMaxLoc(result)

        matching_result = FontPatternMatchingResult()
        matching_result.target = self.target_source.name

        # 検索結果の左上頂点の座標を取得
        matching_result.matching_top_left = max_loc
        # 検索結果の右下頂点の座標を取得
        matching_result.matching_bottom_right = ( max_loc[0] + self.reference_source.img.shape[1], max_loc[1] + self.reference_source.img.shape[0], )
        # 検索対象画像内に、検索結果を長方形で描画
        matching = target_cloned_source.copy()
        cv2.rectangle(matching, matching_result.matching_top_left, matching_result.matching_bottom_right, (255, 255, 0, 255), 1)
        
        self.matching_source = SourceImage()
        self.matching_source.img = matching
        self.matching_source.name = f"{self.target_source.name}_matching"
        matching_result.pattern_matching_similarity = max_val

        hist1 = cv2.calcHist(self.reference_source.img, [0], None, [256], [0, 256])
        hist2 = cv2.calcHist(self.target_source.img, [0], None, [256], [0, 256])
        matching_result.histogram_similarity = cv2.compareHist(hist1, hist2, cv2.HISTCMP_CORREL)

        self.matching_result = matching_result