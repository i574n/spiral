import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func f_c0(_ v0: Int32) -> (Int32) -> SpiralArray<Int32> {
    return { (v1: Int32) -> SpiralArray<Int32> in
        var v2: SpiralArray<Int32> = SpiralArray<Int32>([])
        v2 = SpiralArray<Int32>(Array(repeating: 0, count: Int(1)))
        v2.items[Int(0)] = v0
        return v2
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: (Int32) -> SpiralArray<Int32> = { (_: Int32) -> SpiralArray<Int32> in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: SpiralArray<Int32> = SpiralArray<Int32>([])
    v2 = v1(1)
    var v3: Int32 = 0
    v3 = v2.items[Int(0)]
    var v4: Bool = false
    v4 = (v3 == 7)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
