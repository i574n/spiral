import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Idle: US0 { var tag: Int32 { 0 } }
struct US0_Hit: US0 { var f0: Int32; var tag: Int32 { 1 } }
struct US0_Flag: US0 { var f0: Bool; var tag: Int32 { 2 } }
func closure0(_ v0: US0) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v7: Int32 = 0
        switch v0.tag {
            case 2:
                var v3: Bool = (v0 as! US0_Flag).f0
                if (v3) {
                    v7 = 11
                } else {
                    v7 = 5
                }
            case 1:
                var v2: Int32 = (v0 as! US0_Hit).f0
                v7 = v2
            case 0:
                v7 = 3
            default:
                fatalError("unreachable union case")
        }
        var v8: Int32 = 0
        v8 = (v7 &+ v1)
        return v8
    }
}
func sp_method0(_ p0: @escaping (Int32) -> Int32) -> Int32 {
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
        let v3: Bool = (v0 == 1)
        if (v3) {
            v7 = US0_Hit(f0: 7)
        } else {
            v7 = US0_Flag(f0: true)
        }
    }
    var v8: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v8 = closure0(v7)
    return sp_method0(v8)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
