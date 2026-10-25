import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int8 = Int8(0)
    v0 = Int8(100)
    var v1: Int8 = Int8(0)
    v1 = (v0 &+ v0)
    var v2: UInt8 = UInt8(0)
    v2 = UInt8(200)
    var v3: UInt8 = UInt8(0)
    v3 = UInt8(100)
    var v4: UInt8 = UInt8(0)
    v4 = (v2 &+ v3)
    var v5: Int8 = Int8(0)
    v5 = Int8(-8)
    var v6: Int8 = Int8(0)
    v6 = (v5 >> 1)
    var v7: UInt8 = UInt8(0)
    v7 = (v2 >> 1)
    var v8: Int16 = Int16(0)
    v8 = Int16(20000)
    var v9: Int16 = Int16(0)
    v9 = (v8 &+ v8)
    var v10: UInt16 = UInt16(0)
    v10 = UInt16(40000)
    var v11: UInt16 = UInt16(0)
    v11 = (v10 &+ v10)
    var v12: Int32 = 0
    v12 = 7
    var v13: Int8 = Int8(0)
    v13 = Int8(truncatingIfNeeded: v12)
    var v14: Int8 = Int8(0)
    v14 = Int8(9)
    var v15: Int32 = 0
    v15 = Int32(v14)
    var v16: Bool = false
    v16 = (v1 == Int8(-56))
    var v18: Bool = false
    if (v16) {
        var v17: Bool = false
        v17 = (v4 == UInt8(44))
        v18 = v17
    } else {
        v18 = false
    }
    var v20: Bool = false
    if (v18) {
        var v19: Bool = false
        v19 = (v6 == Int8(-4))
        v20 = v19
    } else {
        v20 = false
    }
    var v22: Bool = false
    if (v20) {
        var v21: Bool = false
        v21 = (v7 == UInt8(100))
        v22 = v21
    } else {
        v22 = false
    }
    var v24: Bool = false
    if (v22) {
        var v23: Bool = false
        v23 = (v9 == Int16(-25536))
        v24 = v23
    } else {
        v24 = false
    }
    var v26: Bool = false
    if (v24) {
        var v25: Bool = false
        v25 = (v11 == UInt16(14464))
        v26 = v25
    } else {
        v26 = false
    }
    var v28: Bool = false
    if (v26) {
        var v27: Bool = false
        v27 = (v13 == Int8(7))
        v28 = v27
    } else {
        v28 = false
    }
    var v30: Bool = false
    if (v28) {
        var v29: Bool = false
        v29 = (v15 == 9)
        v30 = v29
    } else {
        v30 = false
    }
    if (v30) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
