import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: String = "a"
    let v1: String = "b"
    let v2: String = "é"
    let v3: String = "éx"
    let v4: String = ""
    let v5: Bool = (v0 < v0)
    if (v5) {
        return 1
    } else {
        let v6: Bool = (v0 < v1)
        var v8: Bool = false
        if (v6) {
            let v7: Bool = (v1 < v2)
            v8 = v7
        } else {
            v8 = false
        }
        var v10: Bool = false
        if (v8) {
            let v9: Bool = (v2 < v3)
            v10 = v9
        } else {
            v10 = false
        }
        var v12: Bool = false
        if (v10) {
            let v11: Bool = (v4 < v0)
            v12 = v11
        } else {
            v12 = false
        }
        var v14: Bool = false
        if (v12) {
            let v13: Bool = (v0 <= v0)
            v14 = v13
        } else {
            v14 = false
        }
        var v16: Bool = false
        if (v14) {
            let v15: Bool = (v0 >= v0)
            v16 = v15
        } else {
            v16 = false
        }
        var v18: Bool = false
        if (v16) {
            let v17: Bool = (v3 > v2)
            v18 = v17
        } else {
            v18 = false
        }
        var v20: Bool = false
        if (v18) {
            let v19: Bool = (v1 >= v0)
            v20 = v19
        } else {
            v20 = false
        }
        if (v20) {
            return 0
        } else {
            return 1
        }
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
