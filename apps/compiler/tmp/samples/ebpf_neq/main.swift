import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: UInt32 = UInt32(0)
    v2 = UInt32(1)
    var v3: UInt32 = UInt32(0)
    v3 = UInt32(1)
    var v4: Float = (0.0 as Float)
    v4 = (1.5 as Float)
    var v5: Float = (0.0 as Float)
    v5 = (-(v4))
    var v6: Bool = false
    v6 = (v0 != v1)
    if (v6) {
        var v7: Bool = false
        v7 = (v2 != v3)
        if (v7) {
            return 2
        } else {
            var v8: Bool = false
            v8 = (v5 == (-1.5 as Float))
            if (v8) {
                return 0
            } else {
                return 3
            }
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
