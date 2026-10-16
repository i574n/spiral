import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_loop_0(_ p0: Int32, _ p1: SpiralArray<Int32>, _ p2: Int32, _ p3: Int32, _ p4: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: SpiralArray<Int32> = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    var v4: Int32 = p4
    while true {
        var v5: Bool = false
        v5 = (v3 >= v0)
        if (v5) {
            return v4
        } else {
            var v6: Int32 = 0
            v6 = (v3 % 4)
            var v7: Int32 = 0
            v7 = v1.items[Int(v6)]
            var v8: Int32 = 0
            v8 = (v3 &+ 1)
            var v9: Int32 = 0
            v9 = (v4 &* 7)
            var v10: Int32 = 0
            v10 = (v9 &+ v7)
            var v11: Int32 = 0
            v11 = (v10 &+ v2)
            var v12: Int32 = 0
            v12 = (v11 % 9973)
            let t803_0: Int32 = v0
            let t839_1: SpiralArray<Int32> = v1
            let t888_2: Int32 = v2
            let t924_8: Int32 = v8
            let t960_12: Int32 = v12
            v0 = t803_0
            v1 = t839_1
            v2 = t888_2
            v3 = t924_8
            v4 = t960_12
            continue
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Int32> = SpiralArray<Int32>([])
    v0 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4)))
    v0.items[Int(0)] = 1
    v0.items[Int(1)] = 2
    v0.items[Int(2)] = 3
    v0.items[Int(3)] = 4
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = 1000000
    var v3: Int32 = 0
    v3 = 0
    var v4: Int32 = 0
    v4 = 0
    var v5: Int32 = 0
    v5 = sp_loop_0(v2, v0, v1, v3, v4)
    var v6: Int32 = 0
    v6 = (v5 % 256)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
