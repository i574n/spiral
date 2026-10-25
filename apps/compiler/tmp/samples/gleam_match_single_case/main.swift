import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Step: US0 { var f0: Int32; var f1: Int32; var f2: Int32; var tag: Int32 { 0 } }
func sp_walk_0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 > 2)
    var v6: US0 = US0_Step(f0: 0, f1: 0, f2: 0)
    if (v1) {
        var v2: Int32 = 0
        v2 = (v0 &+ 1)
        var v3: Int32 = 0
        v3 = (v0 &+ 2)
        v6 = US0_Step(f0: v0, f1: v2, f2: v3)
    } else {
        v6 = US0_Step(f0: 0, f1: 1, f2: 2)
    }
    switch v6.tag {
        case 0:
            var v7: Int32 = (v6 as! US0_Step).f0
            var v8: Int32 = (v6 as! US0_Step).f1
            var v9: Int32 = (v6 as! US0_Step).f2
            var v10: Int32 = 0
            v10 = (v8 &* v9)
            var v11: Int32 = 0
            v11 = (v7 &+ v10)
            return v11
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 5
    var v1: Int32 = 0
    v1 = sp_walk_0(v0)
    var v2: Int32 = 0
    v2 = (v0 &- 4)
    var v3: Int32 = 0
    v3 = sp_walk_0(v2)
    var v4: Int32 = 0
    v4 = (v1 &+ v3)
    return v4
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
