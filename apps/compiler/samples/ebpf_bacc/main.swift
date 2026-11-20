import CRT
import WinSDK
func sp_method1(_ p0: Int32, _ p1: Bool) -> Bool {
    var v0: Int32 = p0
    var v1: Bool = p1
    while true {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        var v4: Bool = false
        if (v1) {
            let v3: Bool = (v0 > 0)
            v4 = v3
        } else {
            v4 = false
        }
        let v5: Bool = (v2 == 0)
        if (v5) {
            return v4
        } else {
            v0 = v2
            v1 = v4
            continue
        }
    }
    return false
}
func sp_method0(_ p0: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = true
    var v2: Bool = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
func sp_method2(_ p0: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = false
    var v2: Bool = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Bool = false
    v1 = sp_method0(v0)
    var v2: Bool = false
    v2 = sp_method2(v0)
    if (v1) {
        if (v2) {
            return 1
        } else {
            return 0
        }
    } else {
        return 2
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
