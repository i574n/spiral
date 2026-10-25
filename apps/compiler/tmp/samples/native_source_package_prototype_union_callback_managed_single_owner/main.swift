import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Idle: US0 { var tag: Int32 { 0 } }
struct US0_Text: US0 { var f0: String; var tag: Int32 { 1 } }
func closure0() -> (Int32) -> US0 {
    return { (v0: Int32) -> US0 in
        var v1: String = ""
        v1 = "managed"
        return US0_Text(f0: v1)
    }
}
func sp_method0(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(2)
}
func spiral_main() -> Int32 {
    var v0: (Int32) -> US0 = { (_: Int32) -> US0 in fatalError("unreachable closure") }
    v0 = closure0()
    var v1: US0 = US0_Idle()
    v1 = sp_method0(v0)
    var v4: Int32 = 0
    switch v1.tag {
        case 0:
            v4 = 3
        case 1:
            var v2: String = (v1 as! US0_Text).f0
            v4 = 11
        default:
            fatalError("unreachable union case")
    }
    var v5: Int32 = 0
    v5 = (v4 &+ 31)
    return v5
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
