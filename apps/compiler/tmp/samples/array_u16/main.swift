import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<UInt16> = SpiralArray<UInt16>([])
    v0 = SpiralArray<UInt16>(Array(repeating: UInt16(0), count: Int(1)))
    var v1: UInt16 = UInt16(0)
    v1 = UInt16(40000)
    v0.items[Int(0)] = v1
    var v2: UInt16 = UInt16(0)
    v2 = v0.items[Int(0)]
    var v3: Bool = false
    v3 = (v2 == UInt16(40000))
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
