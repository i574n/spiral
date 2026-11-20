import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Empty: US0 { var tag: Int32 { 0 } }
struct US0_Values: US0 { var f0: SpiralArray<Int32>; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func closure0() -> (Int32) -> US0 {
    return { (v0: Int32) -> US0 in
        var v1: Bool = false
        v1 = (v0 == 0)
        if (v1) {
            return US0_Empty()
        } else {
            var v3: SpiralArray<Int32> = SpiralArray<Int32>([])
            v3 = SpiralArray<Int32>(Array(repeating: 0, count: Int(2)))
            v3.items[Int(0)] = v0
            var v4: Int32 = 0
            v4 = (v0 &+ 1)
            v3.items[Int(1)] = v4
            return US0_Values(f0: v3)
        }
    }
}
func sp_method0(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(0)
}
func sp_score_1(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 0:
            return 3
        case 1:
            var v1: SpiralArray<Int32> = (v0 as! US0_Values).f0
            var v2: Int32 = 0
            v2 = Int32(v1.items.count)
            var v3: Int32 = 0
            v3 = v1.items[Int(0)]
            var v4: Int32 = 0
            v4 = (v2 &+ v3)
            var v5: Int32 = 0
            v5 = v1.items[Int(1)]
            var v6: Int32 = 0
            v6 = (v4 &+ v5)
            return v6
        default:
            fatalError("unreachable union case")
    }
}
func sp_method2(_ p0: @escaping (Int32) -> US0) -> US0 {
    var v0: (Int32) -> US0 = p0
    return v0(4)
}
func spiral_main() -> Int32 {
    let v0: (Int32) -> US0 = closure0()
    var v1: US0 = US0_Empty()
    v1 = sp_method0(v0)
    var v2: Int32 = 0
    v2 = sp_score_1(v1)
    var v3: US0 = US0_Empty()
    v3 = sp_method2(v0)
    var v4: Int32 = 0
    v4 = sp_score_1(v3)
    var v5: Int32 = 0
    v5 = (v2 &+ v4)
    var v6: Int32 = 0
    v6 = (v5 &+ 28)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
