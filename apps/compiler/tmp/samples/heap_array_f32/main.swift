import CRT
import WinSDK
class Heap0 {
    let l0: SpiralArray<Float>
    let l1: Int32
    init(l0: SpiralArray<Float>, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Float> = SpiralArray<Float>([])
    v0 = SpiralArray<Float>(Array(repeating: (0.0 as Float), count: Int(1)))
    var v1: Float = (0.0 as Float)
    v1 = (1.5 as Float)
    v0.items[Int(0)] = v1
    var v2: Int32 = 0
    v2 = 7
    var v3: Heap0 = Heap0(l0: SpiralArray<Float>([]), l1: 0)
    v3 = Heap0(l0: v0, l1: v2)
    var v4: SpiralArray<Float> = SpiralArray<Float>([])
    var v5: Int32 = 0
    v4 = v3.l0
    v5 = v3.l1
    var v6: Float = (0.0 as Float)
    v6 = v4.items[Int(0)]
    var v7: Bool = false
    v7 = (v6 == (1.5 as Float))
    var v9: Bool = false
    if (v7) {
        var v8: Bool = false
        v8 = (v5 == 7)
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
