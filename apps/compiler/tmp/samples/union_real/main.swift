import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Real: US0 { var f0: Double; var tag: Int32 { 0 } }
struct US0_Whole: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_twice_1(_ p0: Double) -> Int32 {
    var v0: Double = p0
    var v1: Double = (0.0 as Double)
    v1 = (v0 * (2.0 as Double))
    let v2: Int32 = Int32(v1)
    return v2
}
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 0:
            var v1: Double = (v0 as! US0_Real).f0
            return sp_twice_1(v1)
        case 1:
            var v3: Int32 = (v0 as! US0_Whole).f0
            return v3
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: Bool = true
    var v1: Double = (0.0 as Double)
    v1 = (1.5 as Double)
    var v4: US0 = US0_Real(f0: (0.0 as Double))
    if (v0) {
        v4 = US0_Real(f0: v1)
    } else {
        v4 = US0_Whole(f0: 1)
    }
    var v7: US0 = US0_Real(f0: (0.0 as Double))
    if (v0) {
        v7 = US0_Whole(f0: 5)
    } else {
        v7 = US0_Real(f0: v1)
    }
    let v8: Int32 = sp_score_0(v4)
    let v9: Bool = (v8 == 3)
    var v12: Bool = false
    if (v9) {
        let v10: Int32 = sp_score_0(v7)
        let v11: Bool = (v10 == 5)
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
