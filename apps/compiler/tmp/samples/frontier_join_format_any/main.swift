import CRT
import WinSDK
class Mut0 {
    var l0: String
    init(l0: String) {
        self.l0 = l0
    }
}
func sp_method3(_ p0: Mut0, _ p1: String) {
    var v0: Mut0 = p0
    var v1: String = p1
    var v2: String = ""
    v2 = v0.l0
    var v3: String = ""
    v3 = v2 + v1 
    v0.l0 = v3
}
func sp_format_real_2(_ p0: Int32) -> String {
    var v0: Int32 = p0
    var v1: String = ""
    v1 = ""
    var v2: Mut0 = Mut0(l0: "")
    v2 = Mut0(l0: v1)
    var v3: String = ""
    v3 = String(describing: v0)
    sp_method3(v2, v3)
    var v4: String = ""
    v4 = v2.l0
    return v4
}
func sp_method1() -> String {
    var v0: String = ""
    v0 = "Some"
    var v1: String = ""
    v1 = "("
    var v2: String = ""
    v2 = v0 + v1 
    var v3: Int32 = 0
    v3 = 1
    var v4: String = ""
    v4 = sp_format_real_2(v3)
    let v5: String = v2 + v4 
    let v6: String = ")"
    let v7: String = v5 + v6 
    return v7
}
func sp_method0() -> String {
    var v0: String = ""
    v0 = sp_method1()
    var v1: String = ""
    v1 = "x: "
    var v2: String = ""
    v2 = v1 + v0 
    return v2
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = sp_method0()
    var v1: Bool = false
    v1 = (v0 == "")
    if (v1) {
        return 1
    } else {
        return 0
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
