import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int64 = (5000000000 as Int64)
    let v1: Int64 = (-4 as Int64)
    let v2: Int64 = (v0 / v1)
    let v3: Int64 = (1000000 as Int64)
    let v4: Int64 = (v3 &* v3)
    let v5: Int64 = (-8 as Int64)
    let v6: Int64 = (v5 >> 1)
    let v7: Int32 = 7
    let v8: Int64 = Int64(v7)
    let v9: Int64 = (9 as Int64)
    let v10: Int32 = Int32(truncatingIfNeeded: v9)
    let v11: UInt64 = (4294967296 as UInt64)
    let v12: UInt64 = (v11 &+ (1 as UInt64))
    let v13: UInt64 = (v11 >> 1)
    let v14: UInt64 = UInt64(truncatingIfNeeded: v7)
    let v15: Bool = (v2 == (-1250000000 as Int64))
    var v17: Bool = false
    if (v15) {
        let v16: Bool = (v4 == (1000000000000 as Int64))
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Bool = false
    if (v17) {
        let v18: Bool = (v6 == (-4 as Int64))
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Bool = false
    if (v19) {
        let v20: Bool = (v8 == (7 as Int64))
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Bool = false
    if (v21) {
        let v22: Bool = (v10 == 9)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        let v24: Bool = (v12 == (4294967297 as UInt64))
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Bool = false
    if (v25) {
        let v26: Bool = (v13 == (2147483648 as UInt64))
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Bool = false
    if (v27) {
        let v28: Bool = (v14 == (7 as UInt64))
        v29 = v28
    } else {
        v29 = false
    }
    if (v29) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
