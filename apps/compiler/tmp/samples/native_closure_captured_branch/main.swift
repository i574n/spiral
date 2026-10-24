import CRT
import WinSDK
func a_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func b_c1(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func sp_method0(_ p0: @escaping (Int32) -> Int32) -> Int32 {
    var v0: (Int32) -> Int32 = p0
    return v0(40)
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    let v1: Int32 = 3
    var v2: Bool = false
    v2 = true
    var v5: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    if (v2) {
        v5 = a_c0(v0)
    } else {
        v5 = b_c1(v1)
    }
    return sp_method0(v5)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
