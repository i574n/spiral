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
    let v0: Int32 = 2
    var v1: SpiralArray<Heap0> = SpiralArray<Heap0>([])
    v1 = SpiralArray<Heap0>(Array(repeating: Heap0(l0: 0), count: Int(v0)))
    let v2: Int32 = 4
    let v3: Int32 = 6
    let v4: Heap0 = Heap0(l0: v2)
    v1.items[Int(0)] = v4
    let v5: Heap0 = Heap0(l0: v3)
    v1.items[Int(1)] = v5
    let v6: Heap0 = v1.items[Int(0)]
    let v7: Int32 = v6.l0
    let v8: Heap0 = v1.items[Int(1)]
    let v9: Int32 = v8.l0
    let v10: Int32 = (v7 &+ v9)
    let v11: Bool = (v10 == 10)
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
