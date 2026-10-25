import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
func sp_method0(_ p0: Int32) -> (US0, US0) {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: US0 = US0_None()
        v2 = US0_None()
        var v3: US0 = US0_None()
        v3 = US0_None()
        return (v2, v3)
    } else {
        var v4: US0 = US0_None()
        v4 = US0_Some(f0: v0)
        var v5: US0 = US0_None()
        v5 = US0_None()
        return (v4, v5)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: US0 = US0_None()
    var v2: US0 = US0_None()
    let spiral_tuple126 = sp_method0(v0)
    v1 = spiral_tuple126.0
    v2 = spiral_tuple126.1
    switch v1.tag {
        case 0:
            return 1
        case 1:
            var v3: Int32 = (v1 as! US0_Some).f0
            switch v2.tag {
                case 0:
                    var v4: Bool = false
                    v4 = (v3 == 7)
                    if (v4) {
                        return 0
                    } else {
                        return 1
                    }
                case 1:
                    var v6: Int32 = (v2 as! US0_Some).f0
                    return 1
                default:
                    fatalError("unreachable union case")
            }
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
