import CRT
import WinSDK
class Mut0 {
    var l0: Float
    var l1: String
    init(l0: Float, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (1.5 as Float)
    var v1: String = ""
    v1 = "no"
    var v2: Mut0 = Mut0(l0: (0.0 as Float), l1: "")
    v2 = Mut0(l0: v0, l1: v1)
    var v3: SpiralArray<Mut0> = SpiralArray<Mut0>([])
    v3 = SpiralArray<Mut0>(Array(repeating: Mut0(l0: (0.0 as Float), l1: ""), count: Int(1)))
    v3.items[Int(0)] = v2
    var v4: Mut0 = Mut0(l0: (0.0 as Float), l1: "")
    v4 = v3.items[Int(0)]
    var v5: Float = (0.0 as Float)
    v5 = (2.5 as Float)
    var v6: String = ""
    v6 = "hi"
    v4.l0 = v5
    v4.l1 = v6
    var v7: Float = (0.0 as Float)
    var v8: String = ""
    v7 = v4.l0
    v8 = v4.l1
    var v9: Bool = false
    v9 = (v7 == (2.5 as Float))
    var v11: Bool = false
    if (v9) {
        var v10: Bool = false
        v10 = (v8 == "hi")
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
