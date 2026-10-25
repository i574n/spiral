import CRT
import WinSDK
protocol UH0 { var tag: Int32 { get } }
struct UH0_Nil: UH0 { var tag: Int32 { 0 } }
struct UH0_Cons: UH0 { var f0: Int32; var f1: UH0; var tag: Int32 { 1 } }
func sp_sum_0(_ p0: UH0) -> Int32 {
    var v0: UH0 = p0
    switch v0.tag {
        case 1:
            var v1: Int32 = (v0 as! UH0_Cons).f0
            var v2: UH0 = (v0 as! UH0_Cons).f1
            var v3: Int32 = 0
            v3 = sp_sum_0(v2)
            var v4: Int32 = 0
            v4 = (v1 &+ v3)
            return v4
        case 0:
            return 0
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    var v1: Int32 = 0
    v1 = 2
    var v2: Int32 = 0
    v2 = 3
    var v3: UH0 = UH0_Nil()
    v3 = UH0_Nil()
    var v4: UH0 = UH0_Nil()
    v4 = UH0_Cons(f0: v2, f1: v3)
    var v5: UH0 = UH0_Nil()
    v5 = UH0_Cons(f0: v1, f1: v4)
    var v6: UH0 = UH0_Nil()
    v6 = UH0_Cons(f0: v0, f1: v5)
    var v7: Int32 = 0
    v7 = sp_sum_0(v6)
    var v8: Int32 = 0
    v8 = (v7 &- 6)
    return v8
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
