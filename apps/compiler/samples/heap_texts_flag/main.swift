import CRT
import WinSDK
class Heap0 {
    let l0: SpiralArray<String>
    let l1: Bool
    init(l0: SpiralArray<String>, l1: Bool) {
        self.l0 = l0
        self.l1 = l1
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: SpiralArray<String> = SpiralArray<String>([])
    v0 = SpiralArray<String>(Array(repeating: "", count: Int(1)))
    let v1: String = "hi"
    v0.items[Int(0)] = v1
    let v2: Bool = true
    let v3: Heap0 = Heap0(l0: v0, l1: v2)
    var v4: SpiralArray<String> = SpiralArray<String>([])
    var v5: Bool = false
    v4 = v3.l0
    v5 = v3.l1
    let v6: String = v4.items[Int(0)]
    let v7: Bool = (v6 == "hi")
    let v8: Bool = (v7 && v5)
    if (v8) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
