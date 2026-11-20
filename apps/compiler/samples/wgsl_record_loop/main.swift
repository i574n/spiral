import CRT
import WinSDK
func sp_loop_0(_ p0: Int32, _ p1: Int32, _ p2: Int32, _ p3: Int32) -> (Int32, Int32) {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    var v4: Bool = false
    v4 = (v1 >= v0)
    var v9: Int32 = 0
    var v10: Int32 = 0
    if (v4) {
        v9 = v2
        v10 = v3
    } else {
        var v5: Int32 = 0
        v5 = (v1 &+ 1)
        var v6: Int32 = 0
        v6 = (v2 &+ 1)
        var v7: Int32 = 0
        var v8: Int32 = 0
        let spiral_tuple479 = sp_loop_0(v0, v5, v6, v3)
        v7 = spiral_tuple479.0
        v8 = spiral_tuple479.1
        v9 = v7
        v10 = v8
    }
    return (v9, v10)
}
func spiral_main() -> Int32 {
    let v0: Int32 = 5
    let v1: Int32 = 0
    let v2: Int32 = 1
    let v3: Int32 = 2
    var v4: Int32 = 0
    var v5: Int32 = 0
    let spiral_tuple206 = sp_loop_0(v0, v1, v2, v3)
    v4 = spiral_tuple206.0
    v5 = spiral_tuple206.1
    var v6: Int32 = 0
    v6 = (v4 &+ v5)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
