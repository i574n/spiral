import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Call: US0 { var f0: (Int32) -> Int32; var f1: Int32; var tag: Int32 { 1 } }
func add_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: (Int32) -> Int32 = (v0 as! US0_Call).f0
            var v2: Int32 = (v0 as! US0_Call).f1
            var v3: Int32 = 0
            v3 = v1(0)
            var v4: Int32 = 0
            v4 = (v3 &+ v2)
            var v5: Bool = false
            v5 = (v4 == 7)
            if (v5) {
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
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: Bool = false
    v2 = true
    var v6: US0 = US0_None()
    if (v2) {
        var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
        v3 = add_c0(v0)
        v6 = US0_Call(f0: v3, f1: v1)
    } else {
        v6 = US0_None()
    }
    return sp_score_0(v6)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
