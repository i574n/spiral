import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_Living: US0 { var f0: Int32; var f1: Int32; var tag: Int32 { 0 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: SpiralArray<US0> = SpiralArray<US0>(Array(repeating: US0_Living(f0: 0, f1: 0), count: Int(v0)))
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
