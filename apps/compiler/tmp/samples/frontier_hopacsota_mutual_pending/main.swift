import CRT
import WinSDK
func sp_is_odd_1(_ p0: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        return false
    } else {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        return sp_is_even_0(v2)
    }
}
func sp_is_even_0(_ p0: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        return true
    } else {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        return sp_is_odd_1(v2)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 10
    var v1: Bool = false
    v1 = sp_is_even_0(v0)
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
