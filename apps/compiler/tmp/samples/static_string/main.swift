import CRT
import WinSDK
func sp_method0(_ p0: String) -> Bool {
    var v0: String = p0
    return true
}
func spiral_main() -> Int32 {
    let v0: String = "spiral"
    let v1: Bool = sp_method0(v0)
    if (v1) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
