import CRT
import WinSDK
class Mut0 {
    var l0: Int32
    var l1: Int32
    init(l0: Int32, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Mut0 = Mut0(l0: 0, l1: 0)
    v0 = Mut0(l0: 1, l1: 2)
    v0.l0 = 3
    v0.l1 = 4
    var v1: Int32 = 0
    var v2: Int32 = 0
    v1 = v0.l0
    v2 = v0.l1
    var v3: Int32 = 0
    v3 = (v1 &+ v2)
    return v3
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
