import CRT
import WinSDK
func sp_method0(_ p0: Float, _ p1: Float) -> Float {
    var v0: Float = p0
    var v1: Float = p1
    var v2: Float = (0.0 as Float)
    v2 = (v0 * v1)
    var v3: Float = (0.0 as Float)
    v3 = (v2 + (0.5 as Float))
    return v3
}
func spiral_main() -> Int32 {
    let v0: Float = (1.5 as Float)
    let v1: Float = (2.0 as Float)
    var v2: Float = (0.0 as Float)
    v2 = sp_method0(v0, v1)
    var v3: Bool = false
    v3 = (v2 >= (3.5 as Float))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
