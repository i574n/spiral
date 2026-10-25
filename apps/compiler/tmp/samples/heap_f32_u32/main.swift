import CRT
import WinSDK
class Heap0 {
    let l0: Float
    let l1: UInt32
    init(l0: Float, l1: UInt32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (1.5 as Float)
    var v1: UInt32 = UInt32(0)
    v1 = UInt32(4000000000)
    var v2: Heap0 = Heap0(l0: (0.0 as Float), l1: UInt32(0))
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Float = (0.0 as Float)
    var v4: UInt32 = UInt32(0)
    v3 = v2.l0
    v4 = v2.l1
    var v5: Bool = false
    v5 = (v3 == (1.5 as Float))
    var v7: Bool = false
    if (v5) {
        var v6: Bool = false
        v6 = (v4 == UInt32(4000000000))
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
