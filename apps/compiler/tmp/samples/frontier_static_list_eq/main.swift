import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Int32 = 120
    let v1: Bool = (v0 == 32)
    var v3: Bool = false
    if (v1) {
        v3 = true
    } else {
        let v2: Bool = (v0 == 47)
        v3 = v2
    }
    if (v3) {
        return 1
    } else {
        return 0
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
