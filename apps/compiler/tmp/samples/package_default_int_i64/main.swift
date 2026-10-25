import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int64 = (0 as Int64)
    v0 = (3000000000 as Int64)
    var v1: Bool = false
    v1 = (v0 > (2999999999 as Int64))
    if (v1) {
        return 7
    } else {
        return 0
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
