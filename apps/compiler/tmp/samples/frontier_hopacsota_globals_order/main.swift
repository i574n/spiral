import CRT
import WinSDK
// m1
// a1
// c1
// a2
// b1
// m2
func sp_leaf_c_1() -> Int32 {
    return 0
}
func sp_slow_a_0() -> Int32 {
    var v0: Int32 = 0
    v0 = sp_leaf_c_1()
    return v0
}
func sp_fast_b_2() -> Int32 {
    return 0
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = sp_slow_a_0()
    var v1: Int32 = 0
    v1 = sp_fast_b_2()
    var v2: Int32 = 0
    v2 = (v0 &+ v1)
    return v2
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
