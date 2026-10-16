import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    let l1: String
    init(l0: Int32, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
class Heap1 {
    let l0: Heap0
    let l1: Int32
    init(l0: Heap0, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap1; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Heap1 = (v0 as! US0_Held).f0
            var v2: Heap0 = Heap0(l0: 0, l1: "")
            var v3: Int32 = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Int32 = 0
            var v5: String = ""
            v4 = v2.l0
            v5 = v2.l1
            var v6: Bool = false
            v6 = (v4 == 7)
            var v8: Bool = false
            if (v6) {
                var v7: Bool = false
                v7 = (v5 == "hi")
                v8 = v7
            } else {
                v8 = false
            }
            var v10: Bool = false
            if (v8) {
                var v9: Bool = false
                v9 = (v3 == 1)
                v10 = v9
            } else {
                v10 = false
            }
            if (v10) {
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
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 1
    var v4: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v4 = Heap1(l0: v2, l1: v3)
    var v5: SpiralArray<US0> = SpiralArray<US0>([])
    v5 = SpiralArray<US0>(Array(repeating: US0_None(), count: Int(1)))
    var v6: Bool = false
    v6 = true
    var v9: US0 = US0_None()
    if (v6) {
        v9 = US0_Held(f0: v4)
    } else {
        v9 = US0_None()
    }
    v5.items[Int(0)] = v9
    var v10: US0 = US0_None()
    v10 = v5.items[Int(0)]
    return sp_score_0(v10)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
