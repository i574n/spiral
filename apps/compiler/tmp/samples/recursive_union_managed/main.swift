import CRT
import WinSDK
protocol UH0 { var tag: Int32 { get } }
struct UH0_Nil: UH0 { var tag: Int32 { 0 } }
struct UH0_Cons: UH0 { var f0: SpiralArray<Int32>; var f1: UH0; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_sum_0(_ p0: UH0) -> Int32 {
    var v0: UH0 = p0
    switch v0.tag {
        case 1:
            var v1: SpiralArray<Int32> = (v0 as! UH0_Cons).f0
            var v2: UH0 = (v0 as! UH0_Cons).f1
            var v3: Int32 = 0
            v3 = Int32(v1.items.count)
            var v4: Int32 = 0
            v4 = sp_sum_0(v2)
            var v5: Int32 = 0
            v5 = (v3 &+ v4)
            return v5
        case 0:
            return 0
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    let v1: SpiralArray<Int32> = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    let v2: UH0 = UH0_Nil()
    var v3: UH0 = UH0_Nil()
    v3 = UH0_Cons(f0: v1, f1: v2)
    var v4: UH0 = UH0_Nil()
    v4 = UH0_Cons(f0: v1, f1: v3)
    var v5: Int32 = 0
    v5 = sp_sum_0(v4)
    let v6: Int32 = (v5 &- 4)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
