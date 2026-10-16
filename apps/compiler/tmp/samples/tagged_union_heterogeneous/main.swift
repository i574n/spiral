import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Hit: US0 { var f0: Int32; var tag: Int32 { 0 } }
struct US0_Flag: US0 { var f0: Bool; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v2: Bool = (v0 as! US0_Flag).f0
            if (v2) {
                return 9
            } else {
                return 4
            }
        case 0:
            var v1: Int32 = (v0 as! US0_Hit).f0
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = false
    var v3: US0 = US0_Hit(f0: 0)
    if (v0) {
        v3 = US0_Hit(f0: 7)
    } else {
        v3 = US0_Flag(f0: true)
    }
    var v4: Int32 = 0
    v4 = sp_score_0(v3)
    var v5: Int32 = 0
    v5 = (v4 &- 9)
    return v5
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
