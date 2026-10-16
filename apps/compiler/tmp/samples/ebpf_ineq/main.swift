import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = -3
    var v1: Int32 = 0
    v1 = -4
    var v2: Int32 = 0
    v2 = -3
    var v3: UInt32 = UInt32(0)
    v3 = UInt32(4294967295)
    var v4: UInt32 = UInt32(0)
    v4 = UInt32(0)
    var v5: UInt32 = UInt32(0)
    v5 = UInt32(4294967295)
    var v6: Float = (0.0 as Float)
    v6 = (-1.5 as Float)
    var v7: Float = (0.0 as Float)
    v7 = (-0.5 as Float)
    var v8: Float = (0.0 as Float)
    v8 = (-1.5 as Float)
    var v9: Bool = false
    v9 = (v0 != v1)
    var v10: Bool = false
    v10 = (v0 != v2)
    var v11: Bool = false
    v11 = (v3 != v4)
    var v12: Bool = false
    v12 = (v3 != v5)
    var v13: Bool = false
    v13 = (v6 != v7)
    var v14: Bool = false
    v14 = (v6 != v8)
    var v15: Bool = false
    v15 = (v9 && v11)
    var v16: Bool = false
    v16 = (v15 && v13)
    if (v16) {
        if (v10) {
            return 1
        } else {
            if (v12) {
                return 2
            } else {
                if (v14) {
                    return 3
                } else {
                    return 0
                }
            }
        }
    } else {
        return 4
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
