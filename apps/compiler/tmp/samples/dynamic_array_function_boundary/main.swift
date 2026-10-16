import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_method0(_ p0: SpiralArray<Int32>, _ p1: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = v0.items[Int(v1)]
    var v3: Int32 = 0
    v3 = Int32(v0.items.count)
    var v4: Int32 = 0
    v4 = (v2 &+ v3)
    var v5: Int32 = 0
    v5 = (v4 &- 10)
    return v5
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 2
    v1.items[Int(1)] = 5
    v1.items[Int(2)] = 7
    var v2: Int32 = 0
    v2 = 2
    return sp_method0(v1, v2)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
