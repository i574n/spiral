import CRT
import WinSDK
class Heap0 {
    let l0: Int16
    let l1: String
    init(l0: Int16, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Int16 = Int16(0)
    v0 = Int16(20000)
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(l0: Int16(0), l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int16 = Int16(0)
    var v4: String = ""
    v3 = v2.l0
    v4 = v2.l1
    var v5: Bool = false
    v5 = (v3 == Int16(20000))
    var v7: Bool = false
    if (v5) {
        var v6: Bool = false
        v6 = (v4 == "hi")
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
