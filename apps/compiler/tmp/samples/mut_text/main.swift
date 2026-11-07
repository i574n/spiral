import CRT
import WinSDK
class Mut0 {
    var l0: String
    init(l0: String) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    let v0: String = "no"
    var v1: Mut0 = Mut0(l0: "")
    v1 = Mut0(l0: v0)
    let v2: String = "hi"
    v1.l0 = v2
    let v3: String = v1.l0
    let v4: Bool = (v3 == "hi")
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
