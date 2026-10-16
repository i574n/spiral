kernels_main = r"""
"""
from main_auto import *
kernels = kernels_aux + kernels_main
import os
try: # CuPy when a CUDA device answers, otherwise numpy under the same name (SPIRAL_CUDA=0 forces numpy).
    if os.environ.get('SPIRAL_CUDA', '1') == '0': raise ImportError('SPIRAL_CUDA=0')
    import cupy as cp
    if cp.cuda.runtime.getDeviceCount() < 1: raise RuntimeError('no CUDA device')
    cuda = True
except Exception:
    import numpy as cp
    cuda = False
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str

import sys
def target_global_0(v0 : string) -> None:
    del v0
    return 
def main():
    v0 = "SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_pos-p_B64:Ly9Q"
    target_global_0(v0)
    target_global_0(v0)
    del v0
    v1 = "SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_pos-b_B64:Ly9C"
    target_global_0(v1)
    del v1
    v2 = "SPIRAL_TARGET_GLOBAL_RUST_AFTER_MAIN_test-item_B64:Zm4gc3BpcmFsX2F0dHJpYnV0ZV9zbW9rZSgpIHsKICAgIGFzc2VydF9lcSEoNiAqIDcsIDQyKTsKfQo="
    target_global_0(v2)
    del v2
    v3 = "SPIRAL_ITEM_METADATA_TEST_test-item"
    target_global_0(v3)
    del v3
    v4 = "SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_pos-p_B64:Ly9Q"
    target_global_0(v4)
    target_global_0(v4)
    del v4
    v5 = "SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_pos-b_B64:Ly9C"
    target_global_0(v5)
    del v5
    v6 = "SPIRAL_TARGET_GLOBAL_DELPHI_AFTER_MAIN_test-item_B64:cHJvY2VkdXJlIFNwaXJhbFRhcmdldEdsb2JhbFNtb2tlOwpiZWdpbgogIGlmIDYgKiA3IDw+IDQyIHRoZW4gSGFsdCgxKTsKZW5kOwo="
    target_global_0(v6)
    del v6
    return 0

if __name__ == '__main__': sys.exit(main())
