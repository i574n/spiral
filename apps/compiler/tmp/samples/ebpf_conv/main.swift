import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = Int32.min
    let v1: UInt32 = UInt32(4294967295)
    let v2: Int32 = -1
    let v3: Float = (0.0 as Float)
    let v4: Float = (1.9 as Float)
    let v5: Float = (2.9 as Float)
    let v6: UInt32 = UInt32(4294967294)
    let v7: UInt32 = UInt32(5)
    let v8: UInt32 = UInt32(0)
    let v9: Float = (v3 - v4)
    let v10: UInt32 = UInt32(bitPattern: v0)
    let v11: Int32 = Int32(bitPattern: v10)
    let v12: Int32 = Int32(bitPattern: v1)
    let v13: UInt32 = UInt32(bitPattern: v2)
    let v14: Int32 = Int32(v9)
    let v15: Int32 = Int32(v5)
    let v16: UInt32 = (v10 / UInt32(2))
    let v17: UInt32 = (v6 / UInt32(2))
    let v18: UInt32 = (v7 % UInt32(3))
    let v19: UInt32 = (~(v8))
    let v20: UInt32 = (v1 >> 31)
    let v21: Bool = (v0 < -1)
    var v23: Bool = false
    if (v21) {
        let v22: Bool = (v0 <= v0)
        v23 = v22
    } else {
        v23 = false
    }
    var v26: Bool = false
    if (v23) {
        let v24: Bool = (v0 > 0)
        let v25: Bool = (v24 == false)
        v26 = v25
    } else {
        v26 = false
    }
    if (v26) {
        let v27: Bool = (v10 > UInt32(1))
        var v29: Bool = false
        if (v27) {
            let v28: Bool = (v11 == v0)
            v29 = v28
        } else {
            v29 = false
        }
        var v31: Bool = false
        if (v29) {
            let v30: Bool = (v12 == v2)
            v31 = v30
        } else {
            v31 = false
        }
        var v33: Bool = false
        if (v31) {
            let v32: Bool = (v13 == v1)
            v33 = v32
        } else {
            v33 = false
        }
        if (v33) {
            let v34: Bool = (v14 == v2)
            var v36: Bool = false
            if (v34) {
                let v35: Bool = (v15 == 2)
                v36 = v35
            } else {
                v36 = false
            }
            if (v36) {
                let v37: Bool = (v16 == UInt32(1073741824))
                var v39: Bool = false
                if (v37) {
                    let v38: Bool = (v17 == UInt32(2147483647))
                    v39 = v38
                } else {
                    v39 = false
                }
                var v41: Bool = false
                if (v39) {
                    let v40: Bool = (v18 == UInt32(2))
                    v41 = v40
                } else {
                    v41 = false
                }
                if (v41) {
                    let v42: Bool = (v19 == v1)
                    var v44: Bool = false
                    if (v42) {
                        let v43: Bool = (v20 == UInt32(1))
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
