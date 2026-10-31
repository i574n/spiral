import CRT
import WinSDK
func sp_method2(_ p0: Int32, _ p1: Int32, _ p2: Int32, _ p3: Int32) -> (Int32, Int32, Int32) {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    while true {
        var v4: Int32 = 0
        v4 = (v0 &- 1)
        var v5: Int32 = 0
        v5 = (v1 &+ 1)
        var v6: Int32 = 0
        v6 = (v2 &+ 2)
        var v7: Int32 = 0
        v7 = (v3 &+ 3)
        var v8: Bool = false
        v8 = (v4 == 0)
        if (v8) {
            return (v5, v6, v7)
        } else {
            v0 = v4
            v1 = v5
            v2 = v6
            v3 = v7
            continue
        }
    }
    return (0, 0, 0)
}
func sp_method1(_ p0: Int32) -> (Int32, Int32, Int32) {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = 0
    var v3: Int32 = 0
    v3 = 0
    var v4: Bool = false
    v4 = (v0 == 0)
    if (v4) {
        return (v1, v2, v3)
    } else {
        return sp_method2(v0, v1, v2, v3)
    }
}
func sp_method0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = 0
    var v2: Int32 = 0
    var v3: Int32 = 0
    let spiral_tuple129 = sp_method1(v0)
    v1 = spiral_tuple129.0
    v2 = spiral_tuple129.1
    v3 = spiral_tuple129.2
    var v4: Bool = false
    v4 = (v1 == 3)
    var v6: Bool = false
    if (v4) {
        var v5: Bool = false
        v5 = (v2 == 6)
        v6 = v5
    } else {
        v6 = false
    }
    var v8: Bool = false
    if (v6) {
        var v7: Bool = false
        v7 = (v3 == 9)
        v8 = v7
    } else {
        v8 = false
    }
    if (v8) {
        return 0
    } else {
        return 1
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    return sp_method0(v0)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
