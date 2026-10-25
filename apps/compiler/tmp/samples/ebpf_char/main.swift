import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 65
    var v1: Int32 = 0
    v1 = 66
    var v2: Bool = false
    v2 = (v0 == 65)
    if (v2) {
        var v3: Bool = false
        v3 = (v1 == 66)
        if (v3) {
            var v4: Bool = false
            v4 = (v0 == v1)
            if (v4) {
                return 2
            } else {
                return 0
            }
        } else {
            return 3
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
