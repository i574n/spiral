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
import math
i8 = int; i16 = int; i32 = int; i64 = int; u8 = int; u16 = int; u32 = int; u64 = int; f32 = float; f64 = float; char = str; string = str

import sys
def main():
    v0 = 2.7
    v1 = 3.2
    v2 = -2.5
    v3 = 3.5
    v4 = 0.5
    v5 = 1.0
    v6 = 2.7
    v13 = math.floor(v0)
    v23 = v13 == 2.0
    del v13
    v24 = v23 != True
    del v23
    if v24:
        del v0, v1, v2, v3, v4, v5, v6, v24
        return 1
    else:
        del v24
        v31 = math.ceil
        v32 = v31(v0)
        del v31
        v42 = v32 == 3.0
        del v32
        v43 = v42 != True
        del v42
        if v43:
            del v0, v1, v2, v3, v4, v5, v6, v43
            return 2
        else:
            del v43
            v77 = round
            v78 = v77(v0)
            del v0, v77
            v172 = v78 == 3.0
            del v78
            v173 = v172 != True
            del v172
            if v173:
                del v1, v2, v3, v4, v5, v6, v173
                return 3
            else:
                del v173
                v174 = round
                v175 = v174(v1)
                del v1, v174
                v176 = v175 == 3.0
                del v175
                v177 = v176 != True
                del v176
                if v177:
                    del v2, v3, v4, v5, v6, v177
                    return 4
                else:
                    del v177
                    v178 = round
                    v179 = v178(v2)
                    del v2, v178
                    v180 = v179 == -2.0
                    del v179
                    v181 = v180 != True
                    del v180
                    if v181:
                        del v3, v4, v5, v6, v181
                        return 5
                    else:
                        del v181
                        v182 = round
                        v183 = v182(v3)
                        del v3, v182
                        v184 = v183 == 4.0
                        del v183
                        v185 = v184 != True
                        del v184
                        if v185:
                            del v4, v5, v6, v185
                            return 6
                        else:
                            del v185
                            v186 = round
                            v187 = v186(v4)
                            del v4, v186
                            v188 = v187 == 0.0
                            del v187
                            v189 = v188 != True
                            del v188
                            if v189:
                                del v5, v6, v189
                                return 7
                            else:
                                del v189
                                v193 = math.atan2(v5, v5)
                                del v5
                                v203 = v193 * 1000.0
                                del v193
                                v204 = math.floor(v203)
                                del v203
                                v205 = v204 == 785.0
                                del v204
                                v206 = v205 != True
                                del v205
                                if v206:
                                    del v6, v206
                                    return 8
                                else:
                                    del v206
                                    v213 = math.floor(v6)
                                    del v6
                                    v223 = v213 == 2.0
                                    del v213
                                    v224 = v223 != True
                                    del v223
                                    if v224:
                                        del v224
                                        return 9
                                    else:
                                        del v224
                                        return 0

if __name__ == '__main__': sys.exit(main())
