import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v1: Int32 = 0
    v1 = 42
    var v3: Int32 = 0
    v3 = (v1 &- 42)
    return v3
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
