import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 5
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 0
    v1.items[Int(1)] = 1
    v1.items[Int(2)] = 4
    var v2: Int32 = 0
    v2 = 3
    v1.items[Int(v2)] = 9
    var v3: Int32 = 0
    v3 = (v2 &+ 1)
    v1.items[Int(v3)] = 16
    var v4: SpiralArray<Bool> = SpiralArray<Bool>([])
    v4 = SpiralArray<Bool>(Array(repeating: false, count: Int(3)))
    v4.items[Int(0)] = false
    v4.items[Int(1)] = true
    v4.items[Int(2)] = false
    var v5: Int32 = 0
    v5 = v1.items[Int(1)]
    var v6: Int32 = 0
    v6 = v1.items[Int(2)]
    var v7: Int32 = 0
    v7 = (v5 &+ v6)
    var v8: Int32 = 0
    v8 = v1.items[Int(3)]
    var v9: Int32 = 0
    v9 = (v7 &+ v8)
    var v10: Int32 = 0
    v10 = v1.items[Int(4)]
    var v11: Int32 = 0
    v11 = (v9 &+ v10)
    var v12: Bool = false
    v12 = v4.items[Int(1)]
    var v15: Int32 = 0
    if (v12) {
        var v13: Bool = false
        v13 = v4.items[Int(0)]
        if (v13) {
            v15 = 0
        } else {
            v15 = 100
        }
    } else {
        v15 = 0
    }
    var v16: Int32 = 0
    v16 = (v11 &+ v15)
    var v17: Int32 = 0
    v17 = Int32(v1.items.count)
    var v18: Int32 = 0
    v18 = (v16 &+ v17)
    return v18
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
