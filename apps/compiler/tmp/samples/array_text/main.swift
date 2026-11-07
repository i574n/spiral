import CRT
import WinSDK
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 2
    var v1: SpiralArray<String> = SpiralArray<String>([])
    v1 = SpiralArray<String>(Array(repeating: "", count: Int(v0)))
    let v2: String = "hi"
    v1.items[Int(0)] = v2
    let v3: String = "yo"
    v1.items[Int(1)] = v3
    let v4: String = v1.items[Int(0)]
    let v5: Bool = (v4 == "hi")
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
