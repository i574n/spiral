import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    var v1: SpiralArray<UInt32> = SpiralArray<UInt32>([])
    v1 = SpiralArray<UInt32>(Array(repeating: UInt32(0), count: Int(v0)))
    v1.items[Int(0)] = UInt32(4000000000)
    v1.items[Int(1)] = UInt32(1)
    let v2: UInt32 = v1.items[Int(0)]
    let v3: UInt32 = v1.items[Int(1)]
    let v4: UInt32 = (v2 &+ v3)
    let v5: Int32 = Int32(v1.items.count)
    let v6: Bool = (v5 == v0)
    var v8: Bool = false
    if (v6) {
        let v7: Bool = (v4 == UInt32(4000000001))
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
