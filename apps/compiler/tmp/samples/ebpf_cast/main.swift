import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = -2
    var v2: UInt32 = UInt32(0)
    v2 = UInt32(7)
    var v3: Float = (0.0 as Float)
    v3 = (2.9 as Float)
    var v4: Float = (0.0 as Float)
    v4 = Float(v0)
    var v5: Float = (0.0 as Float)
    v5 = Float(v1)
    var v6: Float = (0.0 as Float)
    v6 = Float(v2)
    var v7: UInt32 = UInt32(0)
    v7 = UInt32(v3)
    var v8: Bool = false
    v8 = (v4 == (3.0 as Float))
    var v10: Bool = false
    if (v8) {
        var v9: Bool = false
        v9 = (v5 == (-2.0 as Float))
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Bool = false
    if (v10) {
        var v11: Bool = false
        v11 = (v6 == (7.0 as Float))
        v12 = v11
    } else {
        v12 = false
    }
    var v14: Bool = false
    if (v12) {
        var v13: Bool = false
        v13 = (v7 == UInt32(2))
        v14 = v13
    } else {
        v14 = false
    }
    if (v14) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
