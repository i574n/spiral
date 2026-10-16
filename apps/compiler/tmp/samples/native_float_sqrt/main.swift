import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (144.0 as Float)
    var v1: Double = (0.0 as Double)
    v1 = (81.0 as Double)
    var v2: Float = (0.0 as Float)
    v2 = sqrtf(v0)
    var v3: Double = (0.0 as Double)
    v3 = sqrt(v1)
    var v4: Bool = false
    v4 = (v2 == (12.0 as Float))
    var v6: Bool = false
    if (v4) {
        var v5: Bool = false
        v5 = (v3 == (9.0 as Double))
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
