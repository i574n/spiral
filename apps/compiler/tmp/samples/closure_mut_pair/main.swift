import CRT
import WinSDK
class Mut0 {
    var l0: Int32
    var l1: String
    init(l0: Int32, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func f_c0(_ v0: Mut0) -> (Int32) -> Mut0 {
    return { (v1: Int32) -> Mut0 in
        return v0
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: String = "no"
    let v2: Mut0 = Mut0(l0: v0, l1: v1)
    let v3: (Int32) -> Mut0 = f_c0(v2)
    var v4: Mut0 = Mut0(l0: 0, l1: "")
    v4 = v3(1)
    let v5: Int32 = 7
    let v6: String = "hi"
    v4.l0 = v5
    v4.l1 = v6
    var v7: Int32 = 0
    var v8: String = ""
    v7 = v4.l0
    v8 = v4.l1
    let v9: Bool = (v7 == 7)
    var v11: Bool = false
    if (v9) {
        let v10: Bool = (v8 == "hi")
        v11 = v10
    } else {
        v11 = false
    }
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
