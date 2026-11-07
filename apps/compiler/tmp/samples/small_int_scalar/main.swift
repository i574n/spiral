import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int8 = Int8(100)
    let v1: Int8 = (v0 &+ v0)
    let v2: UInt8 = UInt8(200)
    let v3: UInt8 = UInt8(100)
    let v4: UInt8 = (v2 &+ v3)
    let v5: Int8 = Int8(-8)
    let v6: Int8 = (v5 >> 1)
    let v7: UInt8 = (v2 >> 1)
    let v8: Int16 = Int16(20000)
    let v9: Int16 = (v8 &+ v8)
    let v10: UInt16 = UInt16(40000)
    let v11: UInt16 = (v10 &+ v10)
    let v12: Int32 = 7
    let v13: Int8 = Int8(truncatingIfNeeded: v12)
    let v14: Int8 = Int8(9)
    let v15: Int32 = Int32(v14)
    let v16: Bool = (v1 == Int8(-56))
    var v18: Bool = false
    if (v16) {
        let v17: Bool = (v4 == UInt8(44))
        v18 = v17
    } else {
        v18 = false
    }
    var v20: Bool = false
    if (v18) {
        let v19: Bool = (v6 == Int8(-4))
        v20 = v19
    } else {
        v20 = false
    }
    var v22: Bool = false
    if (v20) {
        let v21: Bool = (v7 == UInt8(100))
        v22 = v21
    } else {
        v22 = false
    }
    var v24: Bool = false
    if (v22) {
        let v23: Bool = (v9 == Int16(-25536))
        v24 = v23
    } else {
        v24 = false
    }
    var v26: Bool = false
    if (v24) {
        let v25: Bool = (v11 == UInt16(14464))
        v26 = v25
    } else {
        v26 = false
    }
    var v28: Bool = false
    if (v26) {
        let v27: Bool = (v13 == Int8(7))
        v28 = v27
    } else {
        v28 = false
    }
    var v30: Bool = false
    if (v28) {
        let v29: Bool = (v15 == 9)
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
