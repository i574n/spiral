import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Float = (-2.0 as Float)
    let v1: Float = (-1.0 as Float)
    let v2: Float = (0.0 as Float)
    let v3: Bool = (v0 < v1)
    var v5: Bool = false
    if (v3) {
        let v4: Bool = (v1 < v2)
        v5 = v4
    } else {
        v5 = false
    }
    var v8: Bool = false
    if (v5) {
        let v6: Bool = (v0 > v1)
        let v7: Bool = (v6 == false)
        v8 = v7
    } else {
        v8 = false
    }
    var v11: Bool = false
    if (v8) {
        let v9: Bool = (v0 >= v1)
        let v10: Bool = (v9 == false)
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Bool = false
    if (v11) {
        let v12: Bool = (v1 <= v2)
        v13 = v12
    } else {
        v13 = false
    }
    if (v13) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
