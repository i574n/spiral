import CRT
import WinSDK
class Heap0 {
    let l0: Float
    let l1: Int32
    init(l0: Float, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    let v0: Float = (1.5 as Float)
    let v1: Int32 = 7
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    var v3: Float = (0.0 as Float)
    var v4: Int32 = 0
    v3 = v2.l0
    v4 = v2.l1
    let v5: Bool = (v3 == (1.5 as Float))
    var v7: Bool = false
    if (v5) {
        let v6: Bool = (v4 == 7)
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
