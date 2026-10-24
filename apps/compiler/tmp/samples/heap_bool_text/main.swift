import CRT
import WinSDK
class Heap0 {
    let l0: Bool
    let l1: String
    init(l0: Bool, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    let v0: Bool = true
    let v1: String = "hi"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    var v3: Bool = false
    var v4: String = ""
    v3 = v2.l0
    v4 = v2.l1
    var v6: Bool = false
    if (v3) {
        let v5: Bool = (v4 == "hi")
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
