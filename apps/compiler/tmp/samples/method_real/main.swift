import CRT
import WinSDK
func sp_method0(_ p0: Int32) -> Double {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        return (0.0 as Double)
    } else {
        return (1.5 as Double)
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    var v1: Double = (0.0 as Double)
    v1 = sp_method0(v0)
    let v2: Bool = (v1 == (1.5 as Double))
    if (v2) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
