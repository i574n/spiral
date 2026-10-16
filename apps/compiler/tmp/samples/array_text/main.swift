import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: SpiralArray<String> = SpiralArray<String>([])
    v1 = SpiralArray<String>(Array(repeating: "", count: Int(v0)))
    var v2: String = ""
    v2 = "hi"
    v1.items[Int(0)] = v2
    var v3: String = ""
    v3 = "yo"
    v1.items[Int(1)] = v3
    var v4: String = ""
    v4 = v1.items[Int(0)]
    var v5: Bool = false
    v5 = (v4 == "hi")
    if (v5) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
