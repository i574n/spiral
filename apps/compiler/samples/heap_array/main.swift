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
    let v0: Int32 = 2
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    let v2: Int32 = 7
    v1.items[Int(0)] = v2
    let v3: Heap0 = Heap0(l0: v1)
    let v4: SpiralArray<Int32> = v3.l0
    let v5: Int32 = v4.items[Int(0)]
    let v6: Bool = (v5 == 7)
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
