import CRT
import WinSDK
func sp_method0(_ p0: Int32) -> (Int32, Int32, Bool) {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = (v0 &+ 2)
    var v2: Bool = false
    v2 = (v0 > 0)
    return (v0, v1, v2)
}
func sp_method1(_ p0: Int32, _ p1: Int32, _ p2: Bool) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Bool = p2
    if (v2) {
        var v3: Int32 = 0
        v3 = (v0 &+ v1)
        let v4: Int32 = (v3 &- 4)
        return v4
    } else {
        return 1
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 1
    var v1: Int32 = 0
    var v2: Int32 = 0
    var v3: Bool = false
    let spiral_tuple132 = sp_method0(v0)
    v1 = spiral_tuple132.0
    v2 = spiral_tuple132.1
    v3 = spiral_tuple132.2
    return sp_method1(v1, v2, v3)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
