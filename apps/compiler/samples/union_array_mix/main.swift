import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: SpiralArray<Int32>; var f1: Int32; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: SpiralArray<Int32> = (v0 as! US0_Held).f0
            var v2: Int32 = (v0 as! US0_Held).f1
            var v3: Int32 = 0
            v3 = v1.items[Int(0)]
            let v4: Int32 = (v3 &+ v2)
            let v5: Bool = (v4 == 7)
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
    let v0: Int32 = 3
    let v1: Int32 = 4
    var v2: SpiralArray<Int32> = SpiralArray<Int32>([])
    v2 = SpiralArray<Int32>(Array(repeating: 0, count: Int(1)))
    v2.items[Int(0)] = v0
    var v3: Bool = false
    v3 = true
    var v6: US0 = US0_None()
    if (v3) {
        v6 = US0_Held(f0: v2, f1: v1)
    } else {
        v6 = US0_None()
    }
    return sp_score_0(v6)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
