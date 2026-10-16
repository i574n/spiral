import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_No: US0 { var f0: Bool; var tag: Int32 { 0 } }
struct US0_Yes: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 0:
            var v1: Bool = (v0 as! US0_No).f0
            if (v1) {
                return 1
            } else {
                return 2
            }
        case 1:
            var v3: Int32 = (v0 as! US0_Yes).f0
            return v3
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v3: US0 = US0_No(f0: false)
    if (v0) {
        v3 = US0_Yes(f0: 7)
    } else {
        v3 = US0_No(f0: false)
    }
    var v6: US0 = US0_No(f0: false)
    if (v0) {
        v6 = US0_No(f0: true)
    } else {
        v6 = US0_Yes(f0: 1)
    }
    var v7: Int32 = 0
    v7 = sp_score_0(v3)
    var v8: Bool = false
    v8 = (v7 == 7)
    var v11: Bool = false
    if (v8) {
        var v9: Int32 = 0
        v9 = sp_score_0(v6)
        var v10: Bool = false
        v10 = (v9 == 1)
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
