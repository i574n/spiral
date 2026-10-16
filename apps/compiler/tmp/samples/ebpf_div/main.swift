import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Int32 = 0
    v1 = -2
    var v2: Int32 = 0
    v2 = -7
    var v3: UInt32 = UInt32(0)
    v3 = UInt32(100)
    var v4: UInt32 = UInt32(0)
    v4 = UInt32(7)
    var v5: Int32 = 0
    v5 = (v0 / v1)
    var v6: Int32 = 0
    v6 = (v0 % v1)
    var v7: Int32 = 0
    v7 = (v2 / v1)
    var v8: Int32 = 0
    v8 = (v2 % v1)
    var v9: UInt32 = UInt32(0)
    v9 = (v3 / v4)
    var v10: UInt32 = UInt32(0)
    v10 = (v3 % v4)
    var v11: Bool = false
    v11 = (v5 == -3)
    var v13: Bool = false
    if (v11) {
        var v12: Bool = false
        v12 = (v6 == 1)
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Bool = false
    if (v13) {
        var v14: Bool = false
        v14 = (v7 == 3)
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Bool = false
    if (v15) {
        var v16: Bool = false
        v16 = (v8 == -1)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Bool = false
    if (v17) {
        var v18: Bool = false
        v18 = (v9 == UInt32(14))
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Bool = false
    if (v19) {
        var v20: Bool = false
        v20 = (v10 == UInt32(2))
        v21 = v20
    } else {
        v21 = false
    }
    if (v21) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
