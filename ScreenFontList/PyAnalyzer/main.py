
from file_io import FileIo
from image import FontPatternMatchingImageSet, FontPatternMatchingResult
import argparse

parser = argparse.ArgumentParser()
parser.add_argument("reference")
parser.add_argument("target")
parser.add_argument("--root_dir", default="batch")
parser.add_argument("--export", default=None)
args = parser.parse_args()

root_dir = args.root_dir
reference = args.reference
target = args.target
export_target = args.export

import os
from typing import List

reference_files =  list(filter( lambda filename: filename.startswith(reference), os.listdir(root_dir)))
target_matching_results : List[FontPatternMatchingResult] = []

## ファイル収集
for ref_file in reference_files:
    target_file = ref_file.replace(reference, target)
    if os.path.isfile(f"{root_dir}/{target_file}"):    
        file_io = FileIo(**{
            "root_dir": root_dir,
            "reference_file": ref_file,
            "target_file": target_file
        })
        
        imageset = FontPatternMatchingImageSet()
        imageset.read(file_io=file_io)
        
        imageset.matching()
        if imageset.matching_source != None:
            imageset.matching_source.write(file_io.root_dir, f"matching__{file_io.target_file}.png")
            
            result = imageset.matching_result
            print(result.target, result.pattern_matching_similarity, result.histogram_similarity, result.matching_top_left, result.matching_bottom_right)
            
            target_matching_results.append(imageset.matching_result)

if export_target != None:
    with open(f"{export_target}", "w") as fd:
        fd.write("target\tpattern_matching_similarity\thistogram_similarity\tmatching_top_left\tmatching_bottom_right\n")
        for target_result in target_matching_results:
            result = target_result
            fd.write( f"{result.target}\t{result.pattern_matching_similarity}\t{result.histogram_similarity}\t{result.matching_top_left}\t{result.matching_bottom_right}\n")
            pass
            
        
        
        
        



