import CRT
import WinSDK
protocol UH0 { var tag: Int32 { get } }
struct UH0_Link: UH0 { var f0: Int32; var f1: UH0; var tag: Int32 { 0 } }
struct UH0_End: UH0 { var tag: Int32 { 1 } }
struct UH0_Zero: UH0 { var tag: Int32 { -1 } }
func sp_build_0(_ p0: Int32, _ p1: UH0) -> UH0 {
    var v0: Int32 = p0
    var v1: UH0 = p1
    while true {
        var v2: Bool = false
        v2 = (v0 == 0)
        if (v2) {
            return v1
        } else {
            var v3: Int32 = 0
            v3 = (v0 &- 1)
            var v4: UH0 = UH0_Link(f0: 0, f1: UH0_Zero())
            v4 = UH0_Link(f0: v0, f1: v1)
            v0 = v3
            v1 = v4
            continue
        }
    }
    return UH0_Link(f0: 0, f1: UH0_Zero())
}
func sp_sum_1(_ p0: UH0, _ p1: Int32) -> Int32 {
    var v0: UH0 = p0
    var v1: Int32 = p1
    switch v0.tag {
        case 1:
            return v1
        case 0:
            var v2: Int32 = (v0 as! UH0_Link).f0
            var v3: UH0 = (v0 as! UH0_Link).f1
            var v4: Int32 = 0
            v4 = (v1 &* 31)
            var v5: Int32 = 0
            v5 = (v4 &+ v2)
            let v6: Int32 = (v5 % 9973)
            return sp_sum_1(v3, v6)
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1000000
    var v1: UH0 = UH0_Link(f0: 0, f1: UH0_Zero())
    v1 = UH0_End()
    var v2: UH0 = UH0_Link(f0: 0, f1: UH0_Zero())
    v2 = sp_build_0(v0, v1)
    var v3: Int32 = 0
    v3 = 0
    var v4: Int32 = 0
    v4 = sp_sum_1(v2, v3)
    var v5: Int32 = 0
    v5 = (v4 % 256)
    return v5
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
