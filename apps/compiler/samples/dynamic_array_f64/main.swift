import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    var v1: SpiralArray<Double> = SpiralArray<Double>([])
    v1 = SpiralArray<Double>(Array(repeating: (0.0 as Double), count: Int(v0)))
    v1.items[Int(0)] = (1.5 as Double)
    v1.items[Int(1)] = (2.5 as Double)
    let v2: Int32 = 1
    let v3: Double = v1.items[Int(v2)]
    let v4: Bool = (v3 >= (2.0 as Double))
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
