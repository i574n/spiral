import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = -1
    var v1: Int32 = 0
    v1 = -8
    var v2: Int32 = 0
    v2 = (~(v0))
    var v3: Int32 = 0
    v3 = (~(v1))
    var v4: Bool = false
    v4 = (v2 == 0)
    var v6: Bool = false
    if (v4) {
        var v5: Bool = false
        v5 = (v3 == 7)
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
