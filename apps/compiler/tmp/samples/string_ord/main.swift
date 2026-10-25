import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "a"
    var v1: String = ""
    v1 = "b"
    var v2: String = ""
    v2 = "é"
    var v3: String = ""
    v3 = "éx"
    var v4: String = ""
    v4 = ""
    var v5: Bool = false
    v5 = (v0 < v0)
    if (v5) {
        return 1
    } else {
        var v6: Bool = false
        v6 = (v0 < v1)
        var v8: Bool = false
        if (v6) {
            var v7: Bool = false
            v7 = (v1 < v2)
            v8 = v7
        } else {
            v8 = false
        }
        var v10: Bool = false
        if (v8) {
            var v9: Bool = false
            v9 = (v2 < v3)
            v10 = v9
        } else {
            v10 = false
        }
        var v12: Bool = false
        if (v10) {
            var v11: Bool = false
            v11 = (v4 < v0)
            v12 = v11
        } else {
            v12 = false
        }
        var v14: Bool = false
        if (v12) {
            var v13: Bool = false
            v13 = (v0 <= v0)
            v14 = v13
        } else {
            v14 = false
        }
        var v16: Bool = false
        if (v14) {
            var v15: Bool = false
            v15 = (v0 >= v0)
            v16 = v15
        } else {
            v16 = false
        }
        var v18: Bool = false
        if (v16) {
            var v17: Bool = false
            v17 = (v3 > v2)
            v18 = v17
        } else {
            v18 = false
        }
        var v20: Bool = false
        if (v18) {
            var v19: Bool = false
            v19 = (v1 >= v0)
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
