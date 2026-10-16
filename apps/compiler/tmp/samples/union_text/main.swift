import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Text: US0 { var f0: String; var tag: Int32 { 0 } }
struct US0_Code: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v4: Int32 = (v0 as! US0_Code).f0
            return v4
        case 0:
            var v1: String = (v0 as! US0_Text).f0
            var v2: Bool = false
            v2 = (v1 == "hi")
            if (v2) {
                return 2
            } else {
                return 3
            }
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v1: String = ""
    v1 = "hi"
    var v4: US0 = US0_Text(f0: "")
    if (v0) {
        v4 = US0_Text(f0: v1)
    } else {
        v4 = US0_Code(f0: 1)
    }
    var v7: US0 = US0_Text(f0: "")
    if (v0) {
        v7 = US0_Code(f0: 5)
    } else {
        v7 = US0_Text(f0: v1)
    }
    var v8: Int32 = 0
    v8 = sp_score_0(v4)
    var v9: Bool = false
    v9 = (v8 == 2)
    var v12: Bool = false
    if (v9) {
        var v10: Int32 = 0
        v10 = sp_score_0(v7)
        var v11: Bool = false
        v11 = (v10 == 5)
        v12 = v11
    } else {
        v12 = false
    }
    if (v12) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
