import CRT
import WinSDK
class Heap0 {
    let l0: SpiralArray<Int32>
    init(l0: SpiralArray<Int32>) {
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
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    var v2: Int32 = 0
    v2 = 7
    v1.items[Int(0)] = v2
    var v3: Heap0 = Heap0(l0: SpiralArray<Int32>([]))
    v3 = Heap0(l0: v1)
    var v4: SpiralArray<Int32> = SpiralArray<Int32>([])
    v4 = v3.l0
    var v5: Int32 = 0
    v5 = v4.items[Int(0)]
    var v6: Bool = false
    v6 = (v5 == 7)
    if (v6) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
