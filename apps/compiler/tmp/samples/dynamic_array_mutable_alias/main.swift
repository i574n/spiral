import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_method0(_ p0: SpiralArray<Int32>) {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = 0
    v1 = 1
    var v2: Int32 = 0
    v2 = 9
    v0.items[Int(v1)] = v2
}
func sp_method1(_ p0: SpiralArray<Int32>) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = v0.items[Int(v1)]
    return v2
}
func sp_method2(_ p0: SpiralArray<Int32>) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = 0
    v1 = 1
    var v2: Int32 = 0
    v2 = v0.items[Int(v1)]
    return v2
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 1
    v1.items[Int(1)] = 2
    sp_method0(v1)
    var v2: Int32 = 0
    v2 = sp_method1(v1)
    let v3: Int32 = sp_method2(v1)
    let v4: Int32 = (v2 &+ v3)
    let v5: Int32 = (v4 &- 10)
    return v5
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
