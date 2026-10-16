import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_fill_0(_ p0: Int32, _ p1: SpiralArray<Int32>, _ p2: Int32) {
    var v0: Int32 = p0
    var v1: SpiralArray<Int32> = p1
    var v2: Int32 = p2
    while true {
        var v3: Bool = false
        v3 = (v2 < v0)
        if (v3) {
            v1.items[Int(v2)] = v2
            var v4: Int32 = 0
            v4 = (v2 &+ 1)
            let t341_0: Int32 = v0
            let t377_1: SpiralArray<Int32> = v1
            let t426_4: Int32 = v4
            v0 = t341_0
            v1 = t377_1
            v2 = t426_4
            continue
        } else {
            return
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 6
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(6)))
    var v2: Int32 = 0
    v2 = 0
    sp_fill_0(v0, v1, v2)
    var v3: Int32 = 0
    v3 = v1.items[Int(5)]
    var v4: Int32 = 0
    v4 = (v3 &+ 2)
    return v4
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
