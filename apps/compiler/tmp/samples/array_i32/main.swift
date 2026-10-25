import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 4
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 10
    v1.items[Int(1)] = 20
    v1.items[Int(2)] = 30
    var v2: Int32 = 0
    v2 = v1.items[Int(0)]
    var v3: Int32 = 0
    v3 = v1.items[Int(1)]
    var v4: Int32 = 0
    v4 = (v2 &+ v3)
    v1.items[Int(3)] = v4
    var v5: Int32 = 0
    v5 = v1.items[Int(2)]
    var v6: Int32 = 0
    v6 = v1.items[Int(3)]
    var v7: Int32 = 0
    v7 = (v5 &+ v6)
    var v8: Int32 = 0
    v8 = Int32(v1.items.count)
    var v9: Bool = false
    v9 = (v8 == v0)
    var v11: Bool = false
    if (v9) {
        var v10: Bool = false
        v10 = (v7 == 60)
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
