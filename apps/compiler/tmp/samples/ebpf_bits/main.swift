import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: UInt32 = UInt32(0)
    v0 = UInt32(4294967295)
    var v1: UInt32 = UInt32(0)
    v1 = UInt32(15)
    var v2: UInt32 = UInt32(0)
    v2 = (v0 & v1)
    var v3: UInt32 = UInt32(0)
    v3 = (v0 | v1)
    var v4: UInt32 = UInt32(0)
    v4 = (v0 ^ v1)
    var v5: UInt32 = UInt32(0)
    v5 = (~(v1))
    var v6: Bool = false
    v6 = (v2 == UInt32(15))
    var v8: Bool = false
    if (v6) {
        var v7: Bool = false
        v7 = (v3 == v0)
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Bool = false
    if (v8) {
        var v9: Bool = false
        v9 = (v4 == v5)
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Bool = false
    if (v10) {
        var v11: Bool = false
        v11 = (v5 == UInt32(4294967280))
        v12 = v11
    } else {
        v12 = false
    }
    if (v12) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
