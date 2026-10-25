import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_method0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 2
    v1.items[Int(1)] = 3
    v1.items[Int(2)] = 5
    v1.items[Int(3)] = 7
    var v2: Int32 = 0
    v2 = 2
    var v3: Int32 = 0
    v3 = v1.items[Int(v2)]
    var v4: Int32 = 0
    v4 = Int32(v1.items.count)
    var v5: Int32 = 0
    v5 = (v3 &+ v4)
    var v6: Int32 = 0
    v6 = (v5 &- 9)
    return v6
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 4
    return sp_method0(v0)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
