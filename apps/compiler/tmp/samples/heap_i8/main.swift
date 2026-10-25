import CRT
import WinSDK
class Heap0 {
    let l0: Int8
    init(l0: Int8) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    let v0: Int8 = Int8(100)
    let v1: Heap0 = Heap0(l0: v0)
    let v2: Int8 = v1.l0
    let v3: Bool = (v2 == Int8(100))
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
