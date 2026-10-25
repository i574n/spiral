import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Idle: US0 { var tag: Int32 { 0 } }
struct US0_Hit: US0 { var f0: Int32; var tag: Int32 { 1 } }
struct US0_Flag: US0 { var f0: Bool; var tag: Int32 { 2 } }
func closure0(_ v0: Int32) -> (Int32) -> US0 {
    return { (v1: Int32) -> US0 in
        var v2: Bool = false
        v2 = (v1 == v0)
        return US0_Flag(f0: v2)
    }
}
func sp_method0(_ p0: @escaping (Int32) -> US0, _ p1: Int32) -> US0 {
    var v0: (Int32) -> US0 = p0
    var v1: Int32 = p1
    return v0(v1)
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: (Int32) -> US0 = { (_: Int32) -> US0 in fatalError("unreachable closure") }
    v1 = closure0(v0)
    var v2: US0 = US0_Idle()
    v2 = sp_method0(v1, v0)
    var v8: Int32 = 0
    switch v2.tag {
        case 2:
            var v4: Bool = (v2 as! US0_Flag).f0
            if (v4) {
                v8 = 11
            } else {
                v8 = 5
            }
        case 1:
            var v3: Int32 = (v2 as! US0_Hit).f0
            v8 = v3
        case 0:
            v8 = 3
        default:
            fatalError("unreachable union case")
    }
    var v9: Int32 = 0
    v9 = (v8 &+ 31)
    return v9
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
