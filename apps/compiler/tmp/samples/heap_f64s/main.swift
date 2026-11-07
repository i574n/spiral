import CRT
import WinSDK
class Heap0 {
    let l0: SpiralArray<Double>
    init(l0: SpiralArray<Double>) {
        self.l0 = l0
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Double> = SpiralArray<Double>([])
    v0 = SpiralArray<Double>(Array(repeating: (0.0 as Double), count: Int(1)))
    let v1: Double = (1.5 as Double)
    v0.items[Int(0)] = v1
    let v2: Heap0 = Heap0(l0: v0)
    let v3: SpiralArray<Double> = v2.l0
    let v4: Double = v3.items[Int(0)]
    let v5: Bool = (v4 == (1.5 as Double))
    if (v5) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
