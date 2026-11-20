import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func f_c0(_ v0: SpiralArray<Int32>) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        let v2: Int32 = Int32(v0.items.count)
        let v3: Int32 = (v2 &+ v1)
        return v3
    }
}
func spiral_main() -> Int32 {
    let v0: SpiralArray<Int32> = SpiralArray<Int32>(Array(repeating: 0, count: Int(2)))
    let v1: (Int32) -> Int32 = f_c0(v0)
    return v1(40)
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
