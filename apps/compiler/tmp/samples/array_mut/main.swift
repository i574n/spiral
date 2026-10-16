import CRT
import WinSDK
class Mut0 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Mut0> = SpiralArray<Mut0>([])
    v0 = SpiralArray<Mut0>(Array(repeating: Mut0(l0: 0), count: Int(1)))
    var v1: Mut0 = Mut0(l0: 0)
    v1 = Mut0(l0: 1)
    v0.items[Int(0)] = v1
    var v2: Mut0 = Mut0(l0: 0)
    v2 = v0.items[Int(0)]
    v2.l0 = 7
    var v3: Int32 = 0
    v3 = v2.l0
    var v4: Bool = false
    v4 = (v3 == 7)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
