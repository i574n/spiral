import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Empty: US0 { var tag: Int32 { 0 } }
struct US0_Nested: US0 { var f0: SpiralArray<SpiralArray<Int32>>; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 0:
            return 0
        case 1:
            var v1: SpiralArray<SpiralArray<Int32>> = (v0 as! US0_Nested).f0
            var v2: SpiralArray<Int32> = SpiralArray<Int32>([])
            v2 = v1.items[Int(0)]
            var v3: SpiralArray<Int32> = SpiralArray<Int32>([])
            v3 = v1.items[Int(1)]
            var v4: Int32 = 0
            v4 = Int32(v1.items.count)
            var v5: Int32 = 0
            v5 = v2.items[Int(0)]
            var v6: Int32 = 0
            v6 = (v4 &+ v5)
            var v7: Int32 = 0
            v7 = v2.items[Int(1)]
            var v8: Int32 = 0
            v8 = (v6 &+ v7)
            var v9: Int32 = 0
            v9 = v3.items[Int(0)]
            var v10: Int32 = 0
            v10 = (v8 &+ v9)
            var v11: Int32 = 0
            v11 = v3.items[Int(1)]
            var v12: Int32 = 0
            v12 = (v10 &+ v11)
            return v12
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: SpiralArray<SpiralArray<Int32>> = SpiralArray<SpiralArray<Int32>>([])
    v1 = SpiralArray<SpiralArray<Int32>>(Array(repeating: SpiralArray<Int32>([]), count: Int(v0)))
    var v2: SpiralArray<Int32> = SpiralArray<Int32>([])
    v2 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    var v3: SpiralArray<Int32> = SpiralArray<Int32>([])
    v3 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v2.items[Int(0)] = 3
    v2.items[Int(1)] = 4
    v3.items[Int(0)] = 5
    v3.items[Int(1)] = 6
    v1.items[Int(0)] = v2
    v1.items[Int(1)] = v3
    var v4: US0 = US0_Empty()
    v4 = US0_Nested(f0: v1)
    var v5: Int32 = 0
    v5 = sp_score_0(v4)
    var v6: Int32 = 0
    v6 = (v5 &- 20)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
