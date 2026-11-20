import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Missing: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: SpiralArray<Double>; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Double> = SpiralArray<Double>([])
    v0 = SpiralArray<Double>(Array(repeating: (0.0 as Double), count: Int(1)))
    let v1: Double = (1.5 as Double)
    v0.items[Int(0)] = v1
    let v2: Bool = true
    var v5: US0 = US0_Missing()
    if (v2) {
        v5 = US0_Held(f0: v0)
    } else {
        v5 = US0_Missing()
    }
    switch v5.tag {
        case 1:
            var v6: SpiralArray<Double> = (v5 as! US0_Held).f0
            let v7: Double = v6.items[Int(0)]
            let v8: Bool = (v7 == (1.5 as Double))
            if (v8) {
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
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
