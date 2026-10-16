import CRT
import WinSDK
func sp_method2() -> Int32 {
    return 14
}
func sp_method1() -> Int32 {
    var v0: Int32 = 0
    v0 = sp_method2()
    var v1: Int32 = 0
    v1 = (14 &+ v0)
    return v1
}
func sp_method0() -> Int32 {
    var v0: Int32 = 0
    v0 = sp_method1()
    var v1: Int32 = 0
    v1 = (14 &+ v0)
    return v1
}
func spiral_main() -> Int32 {
    return sp_method0()
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
