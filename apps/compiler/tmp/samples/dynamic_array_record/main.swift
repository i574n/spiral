import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func sp_method0() -> (SpiralArray<Int32>, Int32) {
    var v0: Int32 = 0
    v0 = 2
    var v1: SpiralArray<Int32> = SpiralArray<Int32>([])
    v1 = SpiralArray<Int32>(Array(repeating: 0, count: Int(v0)))
    v1.items[Int(0)] = 4
    v1.items[Int(1)] = 5
    return (v1, 1)
}
func sp_method1(_ p0: SpiralArray<Int32>, _ p1: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = p1
    let v2: Int32 = v0.items[Int(0)]
    let v3: Int32 = v0.items[Int(1)]
    let v4: Int32 = (v2 &+ v3)
    let v5: Int32 = (v4 &+ v1)
    let v6: Int32 = (v5 &- 10)
    return v6
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v1: Int32 = 0
    let spiral_tuple111 = sp_method0()
    v0 = spiral_tuple111.0
    v1 = spiral_tuple111.1
    return sp_method1(v0, v1)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
