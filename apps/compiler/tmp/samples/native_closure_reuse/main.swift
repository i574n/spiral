import CRT
import WinSDK
func f_c0(_ v0: Int32, _ v1: Int32) -> (Int32) -> Int32 {
    return { (v2: Int32) -> Int32 in
        var v3: Int32 = 0
        v3 = (v0 &+ v1)
        var v4: Int32 = 0
        v4 = (v3 &+ v2)
        return v4
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    var v1: Int32 = 0
    v1 = 2
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v2 = f_c0(v0, v1)
    var v3: Int32 = 0
    v3 = v2(10)
    var v4: Int32 = 0
    v4 = v2(20)
    var v5: Int32 = 0
    v5 = v2(3)
    var v6: Int32 = 0
    v6 = (v3 &+ v4)
    var v7: Int32 = 0
    v7 = (v6 &+ v5)
    return v7
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
