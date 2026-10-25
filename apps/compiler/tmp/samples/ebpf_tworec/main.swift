import CRT
import WinSDK
func sp_method1(_ p0: Int32, _ p1: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    while true {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        var v3: Int32 = 0
        v3 = (v1 &+ 3)
        var v4: Bool = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            v0 = v2
            v1 = v3
            continue
        }
    }
    return 0
}
func sp_method0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = 0
    var v2: Bool = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
func sp_method3(_ p0: Int32, _ p1: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    while true {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        var v3: Int32 = 0
        v3 = (v1 &- 2)
        var v4: Bool = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            v0 = v2
            v1 = v3
            continue
        }
    }
    return 0
}
func sp_method2(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = 0
    v1 = 0
    var v2: Bool = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method3(v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 4
    var v1: Int32 = 0
    v1 = sp_method0(v0)
    var v2: Int32 = 0
    v2 = sp_method2(v0)
    var v3: Bool = false
    v3 = (v1 == 12)
    var v5: Bool = false
    if (v3) {
        var v4: Bool = false
        v4 = (v2 == -8)
        v5 = v4
    } else {
        v5 = false
    }
    if (v5) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
