import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_method0(_ p0: SpiralArray<Int32>) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = 0
    v1 = v0.items[Int(0)]
    return v1
}
func sp_method1(_ p0: SpiralArray<Int32>) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = 0
    v1 = v0.items[Int(0)]
    return v1
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 3
    v1.items[Int(1)] = 4
    let v2: Int32 = sp_method0(v1)
    let v3: Int32 = sp_method1(v1)
    let v4: Int32 = (v2 &+ v3)
    let v5: Int32 = (v4 &- 6)
    return v5
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
