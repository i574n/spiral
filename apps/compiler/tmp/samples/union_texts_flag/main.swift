import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: SpiralArray<String>; var f1: Bool; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: SpiralArray<String> = (v0 as! US0_Held).f0
            var v2: Bool = (v0 as! US0_Held).f1
            var v3: String = ""
            v3 = v1.items[Int(0)]
            var v4: Bool = false
            v4 = (v3 == "hi")
            var v5: Bool = false
            v5 = (v4 && v2)
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
    var v0: SpiralArray<String> = SpiralArray<String>([])
    v0 = SpiralArray<String>(Array(repeating: "", count: Int(1)))
    var v1: String = ""
    v1 = "hi"
    v0.items[Int(0)] = v1
    var v2: Bool = false
    v2 = true
    var v5: US0 = US0_None()
    if (v2) {
        v5 = US0_Held(f0: v0, f1: v2)
    } else {
        v5 = US0_None()
    }
    return sp_score_0(v5)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
