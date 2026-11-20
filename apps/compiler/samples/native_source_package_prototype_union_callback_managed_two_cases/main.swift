import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Idle: US0 { var tag: Int32 { 0 } }
struct US0_Text: US0 { var f0: String; var tag: Int32 { 1 } }
struct US0_Note: US0 { var f0: String; var tag: Int32 { 2 } }
func closure0() -> (Int32) -> US0 {
    return { (v0: Int32) -> US0 in
        var v1: Bool = false
        v1 = (v0 == 1)
        if (v1) {
            let v2: String = "alpha"
            return US0_Text(f0: v2)
        } else {
            let v4: String = "beta"
            return US0_Note(f0: v4)
        }
    }
}
func sp_method0(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(1)
}
func sp_method1(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(2)
}
func spiral_main() -> Int32 {
    let v0: (Int32) -> US0 = closure0()
    var v1: US0 = US0_Idle()
    v1 = sp_method0(v0)
    var v6: Int32 = 0
    switch v1.tag {
        case 0:
            v6 = 3
        case 2:
            var v3: String = (v1 as! US0_Note).f0
            v6 = 6
        case 1:
            var v2: String = (v1 as! US0_Text).f0
            v6 = 5
        default:
            fatalError("unreachable union case")
    }
    let v7: US0 = sp_method1(v0)
    var v12: Int32 = 0
    switch v7.tag {
        case 0:
            v12 = 3
        case 2:
            var v9: String = (v7 as! US0_Note).f0
            v12 = 6
        case 1:
            var v8: String = (v7 as! US0_Text).f0
            v12 = 5
        default:
            fatalError("unreachable union case")
    }
    let v13: Int32 = (v6 &+ v12)
    let v14: Int32 = (v13 &+ 31)
    return v14
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
