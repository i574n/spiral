import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: SpiralArray<UInt32> = SpiralArray<UInt32>([])
    v1 = SpiralArray<UInt32>(Array(repeating: UInt32(0), count: Int(v0)))
    v1.items[Int(0)] = UInt32(4000000000)
    v1.items[Int(1)] = UInt32(1)
    var v2: UInt32 = UInt32(0)
    v2 = v1.items[Int(0)]
    var v3: UInt32 = UInt32(0)
    v3 = v1.items[Int(1)]
    var v4: UInt32 = UInt32(0)
    v4 = (v2 &+ v3)
    var v5: Int32 = 0
    v5 = Int32(v1.items.count)
    var v6: Bool = false
    v6 = (v5 == v0)
    var v8: Bool = false
    if (v6) {
        var v7: Bool = false
        v7 = (v4 == UInt32(4000000001))
        v8 = v7
    } else {
        v8 = false
    }
    if (v8) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
