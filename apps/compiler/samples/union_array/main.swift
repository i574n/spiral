import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Missing: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: SpiralArray<Int32>; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    let v2: Int32 = 7
    v1.items[Int(0)] = v2
    let v3: Bool = true
    var v6: US0 = US0_Missing()
    if (v3) {
        v6 = US0_Held(f0: v1)
    } else {
        v6 = US0_Missing()
    }
    switch v6.tag {
        case 1:
            var v7: SpiralArray<Int32> = (v6 as! US0_Held).f0
            let v8: Int32 = v7.items[Int(0)]
            let v9: Bool = (v8 == 7)
            if (v9) {
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
