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
    v22 = v13 == 2.0
    del v13
    v23 = v22 != True
    del v22
    if v23:
        del v0, v1, v2, v3, v4, v5, v6, v23
        return 1
    else:
        del v23
        v30 = math.ceil
        v31 = v30(v0)
        del v30
        v40 = v31 == 3.0
        del v31
        v41 = v40 != True
        del v40
        if v41:
            del v0, v1, v2, v3, v4, v5, v6, v41
            return 2
        else:
            del v41
            v75 = round
            v76 = v75(v0)
            del v0, v75
            v169 = v76 == 3.0
            del v76
            v170 = v169 != True
            del v169
            if v170:
                del v1, v2, v3, v4, v5, v6, v170
                return 3
            else:
                del v170
                v171 = round
                v172 = v171(v1)
                del v1, v171
                v173 = v172 == 3.0
                del v172
                v174 = v173 != True
                del v173
                if v174:
                    del v2, v3, v4, v5, v6, v174
                    return 4
                else:
                    del v174
                    v175 = round
                    v176 = v175(v2)
                    del v2, v175
                    v177 = v176 == -2.0
                    del v176
                    v178 = v177 != True
                    del v177
                    if v178:
                        del v3, v4, v5, v6, v178
                        return 5
                    else:
                        del v178
                        v179 = round
                        v180 = v179(v3)
                        del v3, v179
                        v181 = v180 == 4.0
                        del v180
                        v182 = v181 != True
                        del v181
                        if v182:
                            del v4, v5, v6, v182
                            return 6
                        else:
                            del v182
                            v183 = round
                            v184 = v183(v4)
                            del v4, v183
                            v185 = v184 == 0.0
                            del v184
                            v186 = v185 != True
                            del v185
                            if v186:
                                del v5, v6, v186
                                return 7
                            else:
                                del v186
                                v190 = math.atan2(v5, v5)
                                del v5
                                v199 = v190 * 1000.0
                                del v190
                                v200 = math.floor(v199)
                                del v199
                                v201 = v200 == 785.0
                                del v200
                                v202 = v201 != True
                                del v201
                                if v202:
                                    del v6, v202
                                    return 8
                                else:
                                    del v202
                                    v209 = math.floor(v6)
                                    del v6
                                    v218 = v209 == 2.0
                                    del v209
                                    v219 = v218 != True
                                    del v218
                                    if v219:
                                        del v219
                                        return 9
                                    else:
                                        del v219
                                        return 0

if __name__ == '__main__': sys.exit(main())
