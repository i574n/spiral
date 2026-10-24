import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 4
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 10
    v1.items[Int(1)] = 20
    v1.items[Int(2)] = 30
    let v2: Int32 = v1.items[Int(0)]
    let v3: Int32 = v1.items[Int(1)]
    let v4: Int32 = (v2 &+ v3)
    v1.items[Int(3)] = v4
    let v5: Int32 = v1.items[Int(2)]
    let v6: Int32 = v1.items[Int(3)]
    let v7: Int32 = (v5 &+ v6)
    let v8: Int32 = Int32(v1.items.count)
    let v9: Bool = (v8 == v0)
    var v11: Bool = false
    if (v9) {
        let v10: Bool = (v7 == 60)
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
