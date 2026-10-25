import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = Int32.min
    var v1: UInt32 = UInt32(0)
    v1 = UInt32(4294967295)
    var v2: Int32 = 0
    v2 = -1
    var v3: Float = (0.0 as Float)
    v3 = (0.0 as Float)
    var v4: Float = (0.0 as Float)
    v4 = (1.9 as Float)
    var v5: Float = (0.0 as Float)
    v5 = (2.9 as Float)
    var v6: UInt32 = UInt32(0)
    v6 = UInt32(4294967294)
    var v7: UInt32 = UInt32(0)
    v7 = UInt32(5)
    var v8: UInt32 = UInt32(0)
    v8 = UInt32(0)
    var v9: Float = (0.0 as Float)
    v9 = (v3 - v4)
    var v10: UInt32 = UInt32(0)
    v10 = UInt32(bitPattern: v0)
    var v11: Int32 = 0
    v11 = Int32(bitPattern: v10)
    var v12: Int32 = 0
    v12 = Int32(bitPattern: v1)
    var v13: UInt32 = UInt32(0)
    v13 = UInt32(bitPattern: v2)
    var v14: Int32 = 0
    v14 = Int32(v9)
    var v15: Int32 = 0
    v15 = Int32(v5)
    var v16: UInt32 = UInt32(0)
    v16 = (v10 / UInt32(2))
    var v17: UInt32 = UInt32(0)
    v17 = (v6 / UInt32(2))
    var v18: UInt32 = UInt32(0)
    v18 = (v7 % UInt32(3))
    var v19: UInt32 = UInt32(0)
    v19 = (~(v8))
    var v20: UInt32 = UInt32(0)
    v20 = (v1 >> 31)
    var v21: Bool = false
    v21 = (v0 < -1)
    var v23: Bool = false
    if (v21) {
        var v22: Bool = false
        v22 = (v0 <= v0)
        v23 = v22
    } else {
        v23 = false
    }
    var v26: Bool = false
    if (v23) {
        var v24: Bool = false
        v24 = (v0 > 0)
        var v25: Bool = false
        v25 = (v24 == false)
        v26 = v25
    } else {
        v26 = false
    }
    if (v26) {
        var v27: Bool = false
        v27 = (v10 > UInt32(1))
        var v29: Bool = false
        if (v27) {
            var v28: Bool = false
            v28 = (v11 == v0)
            v29 = v28
        } else {
            v29 = false
        }
        var v31: Bool = false
        if (v29) {
            var v30: Bool = false
            v30 = (v12 == v2)
            v31 = v30
        } else {
            v31 = false
        }
        var v33: Bool = false
        if (v31) {
            var v32: Bool = false
            v32 = (v13 == v1)
            v33 = v32
        } else {
            v33 = false
        }
        if (v33) {
            var v34: Bool = false
            v34 = (v14 == v2)
            var v36: Bool = false
            if (v34) {
                var v35: Bool = false
                v35 = (v15 == 2)
                v36 = v35
            } else {
                v36 = false
            }
            if (v36) {
                var v37: Bool = false
                v37 = (v16 == UInt32(1073741824))
                var v39: Bool = false
                if (v37) {
                    var v38: Bool = false
                    v38 = (v17 == UInt32(2147483647))
                    v39 = v38
                } else {
                    v39 = false
                }
                var v41: Bool = false
                if (v39) {
                    var v40: Bool = false
                    v40 = (v18 == UInt32(2))
                    v41 = v40
                } else {
                    v41 = false
                }
                if (v41) {
                    var v42: Bool = false
                    v42 = (v19 == v1)
                    var v44: Bool = false
                    if (v42) {
                        var v43: Bool = false
                        v43 = (v20 == UInt32(1))
                        v44 = v43
                    } else {
                        v44 = false
                    }
                    if (v44) {
                        return 0
                    } else {
                        return 5
                    }
                } else {
                    return 4
                }
            } else {
                return 3
            }
        } else {
            return 2
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
