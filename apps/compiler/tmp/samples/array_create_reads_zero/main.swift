import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Int32> = SpiralArray<Int32>([])
    v0 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4)))
    v0.items[Int(0)] = 7
    v0.items[Int(1)] = 7
    v0.items[Int(2)] = 7
    v0.items[Int(3)] = 7
    var v1: Int32 = 0
    v1 = v0.items[Int(3)]
    var v2: SpiralArray<Int32> = SpiralArray<Int32>([])
    v2 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4)))
    v2.items[Int(0)] = 5
    var v3: Int32 = 0
    v3 = v2.items[Int(3)]
    var v4: Int32 = 0
    v4 = v2.items[Int(0)]
    var v5: Int32 = 0
    v5 = (v3 &* 100)
    var v6: Int32 = 0
    v6 = (v5 &+ v4)
    var v7: Int32 = 0
    v7 = (v1 &- 7)
    var v8: Int32 = 0
    v8 = (v6 &+ v7)
    return v8
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
