import CRT
import WinSDK
func a_c0() -> (Int32) -> Int32 {
    return { (v0: Int32) -> Int32 in
        var v1: Int32 = 0
        v1 = (v0 &+ 2)
        return v1
    }
}
func b_c1() -> (Int32) -> Int32 {
    return { (v0: Int32) -> Int32 in
        var v1: Int32 = 0
        v1 = (v0 &+ 3)
        return v1
    }
}
func sp_method0(_ p0: @escaping (Int32) -> Int32) -> Int32 {
    var v0: (Int32) -> Int32 = p0
    return v0(40)
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    if (v0) {
        v3 = a_c0()
    } else {
        v3 = b_c1()
    }
    return sp_method0(v3)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
