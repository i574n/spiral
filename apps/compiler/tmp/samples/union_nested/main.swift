import CRT
import WinSDK
protocol US1 { var tag: Int32 { get } }
struct US1_A: US1 { var f0: Int32; var tag: Int32 { 0 } }
struct US1_B: US1 { var f0: Int32; var tag: Int32 { 1 } }
protocol US0 { var tag: Int32 { get } }
struct US0_Wrap: US0 { var f0: US1; var tag: Int32 { 0 } }
struct US0_Other: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_score_inner_1(_ p0: US1) -> Int32 {
    var v0: US1 = p0
    switch v0.tag {
        case 0:
            var v1: Int32 = (v0 as! US1_A).f0
            return v1
        case 1:
            var v2: Int32 = (v0 as! US1_B).f0
            var v3: Int32 = 0
            v3 = (-(v2))
            return v3
        default:
            fatalError("unreachable union case")
    }
}
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v3: Int32 = (v0 as! US0_Other).f0
            return v3
        case 0:
            var v1: US1 = (v0 as! US0_Wrap).f0
            return sp_score_inner_1(v1)
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v4: US0 = US0_Wrap(f0: US1_A(f0: 0))
    if (v0) {
        var v1: US1 = US1_A(f0: 0)
        v1 = US1_A(f0: 7)
        v4 = US0_Wrap(f0: v1)
    } else {
        v4 = US0_Other(f0: 1)
    }
    var v8: US0 = US0_Wrap(f0: US1_A(f0: 0))
    if (v0) {
        v8 = US0_Other(f0: 4)
    } else {
        var v6: US1 = US1_A(f0: 0)
        v6 = US1_B(f0: 2)
        v8 = US0_Wrap(f0: v6)
    }
    var v9: Int32 = 0
    v9 = sp_score_0(v4)
    var v10: Bool = false
    v10 = (v9 == 7)
    var v13: Bool = false
    if (v10) {
        var v11: Int32 = 0
        v11 = sp_score_0(v8)
        var v12: Bool = false
        v12 = (v11 == 4)
        v13 = v12
    } else {
        v13 = false
    }
    if (v13) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
