import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func f_c0(_ v0: Int32, _ v1: Int32) -> (Int32) -> (SpiralArray<Int32>, SpiralArray<Int32>) {
    return { (v2: Int32) -> (SpiralArray<Int32>, SpiralArray<Int32>) in
        var v3: SpiralArray<Int32> = SpiralArray<Int32>([])
        v3 = SpiralArray<Int32>(Array(repeating: 0, count: Int(1)))
        var v4: SpiralArray<Int32> = SpiralArray<Int32>([])
        v4 = SpiralArray<Int32>(Array(repeating: 0, count: Int(1)))
        var v5: Bool = false
        v5 = (v2 == 0)
        if (v5) {
            v3.items[Int(0)] = 0
            v4.items[Int(0)] = 0
            return (v3, v4)
        } else {
            v3.items[Int(0)] = v0
            v4.items[Int(0)] = v1
            return (v3, v4)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: (Int32) -> (SpiralArray<Int32>, SpiralArray<Int32>) = { (_: Int32) -> (SpiralArray<Int32>, SpiralArray<Int32>) in fatalError("unreachable closure") }
    v2 = f_c0(v0, v1)
    var v3: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v4: SpiralArray<Int32> = SpiralArray<Int32>([])
    let spiral_tuple401 = v2(1)
    v3 = spiral_tuple401.0
    v4 = spiral_tuple401.1
    var v5: Int32 = 0
    v5 = v3.items[Int(0)]
    var v6: Int32 = 0
    v6 = v4.items[Int(0)]
    var v7: Int32 = 0
    v7 = (v5 &+ v6)
    var v8: Bool = false
    v8 = (v7 == 7)
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
