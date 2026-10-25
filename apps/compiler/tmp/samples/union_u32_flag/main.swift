import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_All: US0 { var f0: UInt32; var f1: String; var f2: Bool; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: UInt32 = (v0 as! US0_All).f0
            var v2: String = (v0 as! US0_All).f1
            var v3: Bool = (v0 as! US0_All).f2
            var v4: Bool = false
            v4 = (v1 == UInt32(4000000000))
            var v6: Bool = false
            if (v4) {
                var v5: Bool = false
                v5 = (v2 == "hi")
                v6 = v5
            } else {
                v6 = false
            }
            var v7: Bool = false
            v7 = (v6 && v3)
            if (v7) {
                return 0
            } else {
                return 1
            }
        case 0:
            return 1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: UInt32 = UInt32(0)
    v0 = UInt32(4000000000)
    var v1: String = ""
    v1 = "hi"
    var v2: Bool = false
    v2 = true
    var v3: Bool = false
    v3 = true
    var v6: US0 = US0_None()
    if (v3) {
        v6 = US0_All(f0: v0, f1: v1, f2: v2)
    } else {
        v6 = US0_None()
    }
    return sp_score_0(v6)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
