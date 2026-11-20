import CRT
import WinSDK
func sp_method0(_ p0: Int32, _ p1: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    let v2: Int32 = (v0 &+ v1)
    let v3: Int32 = (v2 &- 42)
    return v3
}
func spiral_main() -> Int32 {
    let v0: Int32 = 20
    let v1: Int32 = 22
    return sp_method0(v0, v1)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
