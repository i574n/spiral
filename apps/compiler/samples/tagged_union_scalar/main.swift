import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Hit: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_Miss: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 0:
            var v1: Int32 = (v0 as! US0_Hit).f0
            return v1
        case 1:
            var v2: Int32 = (v0 as! US0_Miss).f0
            var v3: Int32 = 0
            v3 = (-(v2))
            return v3
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: Bool = true
    var v3: US0 = US0_Hit(f0: 0)
    if (v0) {
        v3 = US0_Hit(f0: 7)
    } else {
        v3 = US0_Miss(f0: 3)
    }
    let v4: Int32 = sp_score_0(v3)
    let v5: Int32 = (v4 &- 7)
    return v5
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
