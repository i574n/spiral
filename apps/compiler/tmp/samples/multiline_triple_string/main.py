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
def main():
    v0 = "a \"b\" c"
    v1 = ""
    v2 = "a\\nb"
    v3 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
    v4 = "\ntop\n\nlevel"
    v5 = len(v0)
    v6 = v5 == 7
    del v5
    v7 = v6 != True
    del v6
    if v7:
        del v0, v1, v2, v3, v4, v7
        return 1
    else:
        del v7
        v8 = v0[2]
        del v0
        v9 = v8 == '"'
        del v8
        v10 = v9 != True
        del v9
        if v10:
            del v1, v2, v3, v4, v10
            return 2
        else:
            del v10
            v11 = len(v1)
            del v1
            v12 = v11 == 0
            del v11
            v13 = v12 != True
            del v12
            if v13:
                del v2, v3, v4, v13
                return 3
            else:
                del v13
                v14 = len(v2)
                v15 = v14 == 4
                del v14
                v16 = v15 != True
                del v15
                if v16:
                    del v2, v3, v4, v16
                    return 4
                else:
                    del v16
                    v17 = v2[1]
                    del v2
                    v18 = v17 == '\\'
                    del v17
                    v19 = v18 != True
                    del v18
                    if v19:
                        del v3, v4, v19
                        return 5
                    else:
                        del v19
                        v20 = len(v3)
                        v21 = v20 == 83
                        del v20
                        v22 = v21 != True
                        del v21
                        if v22:
                            del v3, v4, v22
                            return 6
                        else:
                            del v22
                            v23 = v3[5]
                            v24 = v23 == '\n'
                            del v23
                            v25 = v24 != True
                            del v24
                            if v25:
                                del v3, v4, v25
                                return 7
                            else:
                                del v25
                                v26 = v3[37]
                                v27 = v26 == '\n'
                                del v26
                                v28 = v27 != True
                                del v27
                                if v28:
                                    del v3, v4, v28
                                    return 8
                                else:
                                    del v28
                                    v29 = v3[38]
                                    v30 = v29 == '\n'
                                    del v29
                                    v31 = v30 != True
                                    del v30
                                    if v31:
                                        del v3, v4, v31
                                        return 9
                                    else:
                                        del v31
                                        v32 = v3[39]
                                        v33 = v32 == '$'
                                        del v32
                                        v34 = v33 != True
                                        del v33
                                        if v34:
                                            del v3, v4, v34
                                            return 10
                                        else:
                                            del v34
                                            v35 = v3[57]
                                            v36 = v35 == 'i'
                                            del v35
                                            v37 = v36 != True
                                            del v36
                                            if v37:
                                                del v3, v4, v37
                                                return 11
                                            else:
                                                del v37
                                                v38 = v3[82]
                                                del v3
                                                v39 = v38 == 'd'
                                                del v38
                                                v40 = v39 != True
                                                del v39
                                                if v40:
                                                    del v4, v40
                                                    return 12
                                                else:
                                                    del v40
                                                    v41 = len(v4)
                                                    v42 = v41 == 11
                                                    del v41
                                                    v43 = v42 != True
                                                    del v42
                                                    if v43:
                                                        del v4, v43
                                                        return 13
                                                    else:
                                                        del v43
                                                        v44 = v4[0]
                                                        v45 = v44 == '\n'
                                                        del v44
                                                        v46 = v45 != True
                                                        del v45
                                                        if v46:
                                                            del v4, v46
                                                            return 14
                                                        else:
                                                            del v46
                                                            v47 = v4[5]
                                                            del v4
                                                            v48 = v47 == '\n'
                                                            del v47
                                                            v49 = v48 != True
                                                            del v48
                                                            if v49:
                                                                del v49
                                                                return 15
                                                            else:
                                                                del v49
                                                                return 0

if __name__ == '__main__': sys.exit(main())
