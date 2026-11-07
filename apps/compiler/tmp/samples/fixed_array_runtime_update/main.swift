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
    let v1: Int32 = 1
    v0.items[Int(v1)] = 11
    let v2: Int32 = v0.items[Int(0)]
    let v3: Int32 = v0.items[Int(1)]
    let v4: Int32 = v0.items[Int(2)]
    let v5: Int32 = v0.items[Int(3)]
    let v6: Int32 = (v2 &+ v3)
    let v7: Int32 = (v6 &+ v4)
    let v8: Int32 = (v7 &+ v5)
    let v9: Int32 = (v8 &- 25)
    return v9
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
