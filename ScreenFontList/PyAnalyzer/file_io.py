
from pydantic import BaseModel

class FileIo(BaseModel):
    root_dir: str
    reference_file: str
    target_file: str
    

