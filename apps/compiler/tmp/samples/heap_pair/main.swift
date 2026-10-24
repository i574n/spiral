import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    let l1: Int32
    init(l0: Int32, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 4
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    var v4: Int32 = 0
    v3 = v2.l0
    v4 = v2.l1
    let v5: Int32 = (v3 &+ v4)
    let v6: Bool = (v5 == 7)
    if (v6) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
