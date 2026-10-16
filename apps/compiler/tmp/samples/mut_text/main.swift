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
    v0 = "no"
    var v1: Mut0 = Mut0(l0: "")
    v1 = Mut0(l0: v0)
    var v2: String = ""
    v2 = "hi"
    v1.l0 = v2
    var v3: String = ""
    v3 = v1.l0
    var v4: Bool = false
    v4 = (v3 == "hi")
    if (v4) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
