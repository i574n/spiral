import CRT
import WinSDK
func sp_method1(_ p0: Int32, _ p1: Int32) -> (Int32, Int32) {
    var v0: Int32 = p0
    var v1: Int32 = p1
    return (v0, v1)
}
func sp_method0(_ p0: Int32, _ p1: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    var v3: Int32 = 0
    let spiral_tuple143 = sp_method1(v0, v1)
    v2 = spiral_tuple143.0
    v3 = spiral_tuple143.1
    var v4: Int32 = 0
    v4 = (v2 &+ v3)
    return v4
}
func sp_method3(_ p0: Int32, _ p1: Int32, _ p2: Int32) -> (Int32, Int32, Int32) {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    return (v0, v1, v2)
}
func sp_method2(_ p0: Int32, _ p1: Int32, _ p2: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = 0
    var v4: Int32 = 0
    var v5: Int32 = 0
    let spiral_tuple201 = sp_method3(v0, v1, v2)
    v3 = spiral_tuple201.0
    v4 = spiral_tuple201.1
    v5 = spiral_tuple201.2
    var v6: Int32 = 0
    v6 = (v3 &+ v4)
    let v7: Int32 = (v6 &+ v5)
    return v7
}
func spiral_main() -> Int32 {
    let v0: Int32 = 1
    let v1: Int32 = 2
    var v2: Int32 = 0
    v2 = 3
    var v3: Int32 = 0
    v3 = sp_method0(v0, v1)
    var v4: Int32 = 0
    v4 = sp_method2(v0, v1, v2)
    var v5: Int32 = 0
    v5 = (v3 &+ v4)
    var v6: Int32 = 0
    v6 = (v5 &- 9)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
