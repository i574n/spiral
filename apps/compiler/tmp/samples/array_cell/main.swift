import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: SpiralArray<Heap0> = SpiralArray<Heap0>([])
    v1 = SpiralArray<Heap0>(Array(repeating: Heap0(l0: 0), count: Int(v0)))
    var v2: Int32 = 0
    v2 = 4
    var v3: Int32 = 0
    v3 = 6
    var v4: Heap0 = Heap0(l0: 0)
    v4 = Heap0(l0: v2)
    v1.items[Int(0)] = v4
    var v5: Heap0 = Heap0(l0: 0)
    v5 = Heap0(l0: v3)
    v1.items[Int(1)] = v5
    var v6: Heap0 = Heap0(l0: 0)
    v6 = v1.items[Int(0)]
    var v7: Int32 = 0
    v7 = v6.l0
    var v8: Heap0 = Heap0(l0: 0)
    v8 = v1.items[Int(1)]
    var v9: Int32 = 0
    v9 = v8.l0
    var v10: Int32 = 0
    v10 = (v7 &+ v9)
    var v11: Bool = false
    v11 = (v10 == 10)
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
