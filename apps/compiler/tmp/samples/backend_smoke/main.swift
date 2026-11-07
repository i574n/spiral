import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = 6
    let v1: Int32 = 7
    let v2: Int32 = (v0 &+ v1)
    return v2
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
