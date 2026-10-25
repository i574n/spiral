import CRT
import WinSDK
protocol UH0 { var tag: Int32 { get } }
struct UH0_Leaf: UH0 { var tag: Int32 { 0 } }
struct UH0_Node: UH0 { var f0: Int32; var f1: UH0; var f2: UH0; var tag: Int32 { 1 } }
func sp_sum_0(_ p0: UH0) -> Int32 {
    var v0: UH0 = p0
    switch v0.tag {
        case 0:
            return 0
        case 1:
            var v1: Int32 = (v0 as! UH0_Node).f0
            var v2: UH0 = (v0 as! UH0_Node).f1
            var v3: UH0 = (v0 as! UH0_Node).f2
            var v4: Int32 = 0
            v4 = sp_sum_0(v2)
            var v5: Int32 = 0
            v5 = sp_sum_0(v3)
            var v6: Int32 = 0
            v6 = (v4 &+ v5)
            var v7: Int32 = 0
            v7 = (v1 &+ v6)
            return v7
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    var v1: Int32 = 0
    v1 = 2
    var v2: UH0 = UH0_Leaf()
    v2 = UH0_Leaf()
    var v3: UH0 = UH0_Leaf()
    v3 = UH0_Node(f0: v1, f1: v2, f2: v2)
    var v4: UH0 = UH0_Leaf()
    v4 = UH0_Node(f0: v0, f1: v3, f2: v3)
    var v5: Int32 = 0
    v5 = sp_sum_0(v4)
    var v6: Int32 = 0
    v6 = (v5 &- 5)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
