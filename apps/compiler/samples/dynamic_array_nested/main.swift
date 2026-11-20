import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    var v1: SpiralArray<SpiralArray<Int32>> = SpiralArray<SpiralArray<Int32>>([])
    v1 = SpiralArray<SpiralArray<Int32>>(Array(repeating: SpiralArray<Int32>([]), count: Int(v0)))
    var v2: SpiralArray<Int32> = SpiralArray<Int32>([])
    v2 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    var v3: SpiralArray<Int32> = SpiralArray<Int32>([])
    v3 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v2.items[Int(0)] = 3
    v2.items[Int(1)] = 4
    v3.items[Int(0)] = 5
    v3.items[Int(1)] = 6
    v1.items[Int(0)] = v2
    v1.items[Int(1)] = v3
    let v4: SpiralArray<Int32> = v1.items[Int(0)]
    let v5: SpiralArray<Int32> = v1.items[Int(1)]
    let v6: Int32 = v4.items[Int(0)]
    let v7: Int32 = v4.items[Int(1)]
    let v8: Int32 = (v6 &+ v7)
    let v9: Int32 = v5.items[Int(0)]
    let v10: Int32 = (v8 &+ v9)
    let v11: Int32 = v5.items[Int(1)]
    let v12: Int32 = (v10 &+ v11)
    let v13: Int32 = (v12 &- 18)
    return v13
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
