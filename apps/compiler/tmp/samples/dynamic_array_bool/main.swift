import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: SpiralArray<Bool> = SpiralArray<Bool>([])
    v1 = SpiralArray<Bool>(Array(repeating: false, count: Int(v0)))
    v1.items[Int(0)] = true
    v1.items[Int(1)] = false
    var v2: Int32 = 0
    v2 = 0
    var v3: Bool = false
    v3 = v1.items[Int(v2)]
    if (v3) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
