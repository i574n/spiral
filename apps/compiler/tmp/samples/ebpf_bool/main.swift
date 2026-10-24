import CRT
import WinSDK
func sp_method0(_ p0: Bool) -> Int32 {
    var v0: Bool = p0
    if (v0) {
        return 1
    } else {
        return 3
    }
}
func sp_method1(_ p0: Bool, _ p1: Bool) -> Int32 {
    var v0: Bool = p0
    var v1: Bool = p1
    var v2: Bool = false
    v2 = (v0 && v1)
    if (v2) {
        return 1
    } else {
        var v3: Bool = false
        v3 = (v0 || v1)
        if (v3) {
            return 2
        } else {
            return 3
        }
    }
}
func sp_method2(_ p0: Bool) -> Int32 {
    var v0: Bool = p0
    if (v0) {
        return 1
    } else {
        return 3
    }
}
func spiral_main() -> Int32 {
    let v0: Bool = true
    let v1: Bool = false
    var v2: Int32 = 0
    v2 = sp_method0(v0)
    var v3: Int32 = 0
    v3 = sp_method1(v0, v1)
    let v4: Int32 = sp_method2(v1)
    let v5: Bool = (v0 == v1)
    let v6: Bool = (v5 == false)
    let v7: Bool = (v2 == 1)
    var v9: Bool = false
    if (v7) {
        let v8: Bool = (v3 == 2)
        v9 = v8
    } else {
        v9 = false
    }
    var v11: Bool = false
    if (v9) {
        let v10: Bool = (v4 == 3)
        v11 = v10
    } else {
        v11 = false
    }
    let v12: Bool = (v11 && v6)
    if (v12) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
