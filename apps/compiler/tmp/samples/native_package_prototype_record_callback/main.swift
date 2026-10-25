import CRT
import WinSDK
func closure0(_ v0: Int32) -> (Int32, Int32) -> (Int32, Int32) {
    return { (v1: Int32, v2: Int32) -> (Int32, Int32) in
        var v3: Int32 = 0
        v3 = (v1 &- 8)
        var v4: Int32 = 0
        v4 = (v3 &+ v0)
        var v5: Int32 = 0
        v5 = (v2 &- 18)
        return (v4, v5)
    }
}
func sp_method0(_ p0: @escaping (Int32, Int32) -> (Int32, Int32)) -> (Int32, Int32) {
    var v0: (Int32, Int32) -> (Int32, Int32) = p0
    return v0(10, 20)
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    var v1: (Int32, Int32) -> (Int32, Int32) = { (_: Int32, _: Int32) -> (Int32, Int32) in fatalError("unreachable closure") }
    v1 = closure0(v0)
    var v2: Int32 = 0
    var v3: Int32 = 0
    let spiral_tuple263 = sp_method0(v1)
    v2 = spiral_tuple263.0
    v3 = spiral_tuple263.1
    var v4: Int32 = 0
    v4 = (10 &+ v2)
    var v5: Int32 = 0
    v5 = (20 &+ v3)
    var v6: Int32 = 0
    v6 = (v4 &+ v5)
    var v7: Int32 = 0
    v7 = (v6 &+ 7)
    return v7
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
