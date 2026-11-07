import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Idle: US0 { var tag: Int32 { 0 } }
struct US0_Hit: US0 { var f0: Int32; var tag: Int32 { 1 } }
struct US0_Flag: US0 { var f0: Bool; var tag: Int32 { 2 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 2:
            var v2: Bool = (v0 as! US0_Flag).f0
            if (v2) {
                return 11
            } else {
                return 5
            }
        case 1:
            var v1: Int32 = (v0 as! US0_Hit).f0
            return v1
        case 0:
            return 3
        default:
            fatalError("unreachable union case")
    }
}
func closure0(_ v0: US0) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        let v2: Int32 = sp_score_0(v0)
        var v3: Int32 = 0
        v3 = (v2 &+ v1)
        return v3
    }
}
func sp_method1(_ p0: @escaping (Int32) -> Int32) -> Int32 {
    var v0: (Int32) -> Int32 = p0
    return v0(31)
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    let v1: Bool = (v0 == 0)
    var v7: US0 = US0_Idle()
    if (v1) {
        v7 = US0_Idle()
    } else {
        var v3: Bool = false
        v3 = (v0 == 1)
        if (v3) {
            v7 = US0_Hit(f0: 7)
        } else {
            v7 = US0_Flag(f0: true)
        }
    }
    let v8: (Int32) -> Int32 = closure0(v7)
    return sp_method1(v8)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
