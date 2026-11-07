import CRT
import WinSDK
class Mut0 {
    var l0: Int64
    var l1: String
    init(l0: Int64, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    let v0: Int64 = (3 as Int64)
    let v1: String = "no"
    var v2: Mut0 = Mut0(l0: (0 as Int64), l1: "")
    v2 = Mut0(l0: v0, l1: v1)
    let v3: Int64 = (5000000000 as Int64)
    let v4: String = "hi"
    v2.l0 = v3
    v2.l1 = v4
    var v5: Int64 = (0 as Int64)
    var v6: String = ""
    v5 = v2.l0
    v6 = v2.l1
    let v7: Bool = (v5 == (5000000000 as Int64))
    var v9: Bool = false
    if (v7) {
        let v8: Bool = (v6 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
