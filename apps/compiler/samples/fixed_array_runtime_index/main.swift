import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Int32> = SpiralArray<Int32>([])
    v0 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4)))
    v0.items[Int(0)] = 2
    v0.items[Int(1)] = 3
    v0.items[Int(2)] = 5
    v0.items[Int(3)] = 7
    let v1: Int32 = 2
    let v2: Int32 = v0.items[Int(v1)]
    let v3: Int32 = (v2 &- 5)
    return v3
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
