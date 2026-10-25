import CRT
import WinSDK
class Mut0 {
    var l0: String
    init(l0: String) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "deref"
    var v1: Mut0 = Mut0(l0: "")
    v1 = Mut0(l0: v0)
    var v2: Int32 = 0
    v2 = 3
    var v3: String = ""
    v3 = "deref!"
    v1.l0 = v3
    var v4: String = ""
    v4 = v1.l0
    var v5: Bool = false
    v5 = (v2 == 3)
    var v7: Int32 = 0
    if (v5) {
        var v6: Int32 = 0
        v6 = (v2 &+ 1)
        v7 = v6
    } else {
        v7 = 0
    }
    _ = fputs(v4 + " " + String(v7) + "\n", stdout)
    var v8: Int32 = 0
    v8 = (v2 &* 2)
    var v9: Bool = false
    v9 = (v2 > 0)
    var v10: Int32 = 0
    if (v9) {
        v10 = 6
    } else {
        v10 = 0
    }
    var v11: Bool = false
    v11 = (v8 == v10)
    if (v11) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
