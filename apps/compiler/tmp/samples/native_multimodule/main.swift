import CRT
import WinSDK
func sp_method0(_ p0: Int32, _ p1: Int32, _ p2: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = 0
    v3 = (v0 &* v1)
    var v4: Int32 = 0
    v4 = (v3 &+ v2)
    var v5: Int32 = 0
    v5 = (v4 &- 42)
    return v5
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 5
    var v1: Int32 = 0
    v1 = 8
    var v2: Int32 = 0
    v2 = 2
    return sp_method0(v0, v1, v2)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
