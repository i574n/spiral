import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Int64> = SpiralArray<Int64>([])
    v0 = SpiralArray<Int64>(Array(repeating: (0 as Int64), count: Int(2)))
    let v1: Int64 = (5000000000 as Int64)
    v0.items[Int(1)] = v1
    let v2: Int64 = v0.items[Int(1)]
    let v3: Bool = (v2 == (5000000000 as Int64))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
