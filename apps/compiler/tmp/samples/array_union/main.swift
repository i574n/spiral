import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Some: US0 { var f0: Int32; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    var v1: SpiralArray<US0> = SpiralArray<US0>([])
    v1 = SpiralArray<US0>(Array(repeating: US0_None(), count: Int(v0)))
    let v2: Int32 = 7
    let v3: US0 = US0_Some(f0: v2)
    v1.items[Int(0)] = v3
    let v4: US0 = US0_None()
    v1.items[Int(1)] = v4
    let v5: US0 = v1.items[Int(0)]
    switch v5.tag {
        case 0:
            return 1
        case 1:
            var v6: Int32 = (v5 as! US0_Some).f0
            let v7: US0 = v1.items[Int(1)]
            switch v7.tag {
                case 0:
                    let v8: Bool = (v6 == 7)
                    if (v8) {
                        return 0
                    } else {
                        return 1
                    }
                case 1:
                    var v10: Int32 = (v7 as! US0_Some).f0
                    return 1
                default:
                    fatalError("unreachable union case")
            }
        default:
            fatalError("unreachable union case")
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
