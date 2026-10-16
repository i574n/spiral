import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_method1(_ p0: Int32, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>) -> SpiralArray<Int32> {
    var v0: Int32 = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    while true {
        var v3: Int32 = 0
        v3 = (v0 &- 1)
        var v4: Bool = false
        v4 = (v3 == 0)
        if (v4) {
            return v2
        } else {
            let t387_3: Int32 = v3
            let t423_2: SpiralArray<Int32> = v2
            let t472_1: SpiralArray<Int32> = v1
            v0 = t387_3
            v1 = t423_2
            v2 = t472_1
            continue
        }
    }
    return SpiralArray<Int32>([])
}
func sp_method0(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>) -> SpiralArray<Int32> {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: Int32 = 0
    v2 = 1000000
    var v3: Bool = false
    v3 = (v2 == 0)
    if (v3) {
        return v0
    } else {
        return sp_method1(v2, v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    var v2: SpiralArray<Int32> = SpiralArray<Int32>([])
    v2 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 7
    v2.items[Int(0)] = 11
    var v3: SpiralArray<Int32> = SpiralArray<Int32>([])
    v3 = sp_method0(v1, v2)
    v3.items[Int(0)] = 13
    var v4: Int32 = 0
    v4 = v1.items[Int(0)]
    var v5: Bool = false
    v5 = (v4 == 13)
    if (v5) {
        var v6: Int32 = 0
        v6 = v2.items[Int(0)]
        var v7: Bool = false
        v7 = (v6 == 11)
        if (v7) {
            return 0
        } else {
            return 2
        }
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
