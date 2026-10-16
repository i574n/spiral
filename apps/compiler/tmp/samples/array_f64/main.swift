import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: SpiralArray<Double> = SpiralArray<Double>([])
    v1 = SpiralArray<Double>(Array(repeating: (0.0 as Double), count: Int(v0)))
    var v2: Double = (0.0 as Double)
    v2 = (1.5 as Double)
    v1.items[Int(0)] = v2
    v1.items[Int(1)] = (2.5 as Double)
    var v3: Double = (0.0 as Double)
    v3 = v1.items[Int(0)]
    var v4: Bool = false
    v4 = (v3 == (1.5 as Double))
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
