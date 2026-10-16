import CRT
import WinSDK
class Heap0 {
    let l0: Int64
    let l1: Double
    init(l0: Int64, l1: Double) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Int64 = (0 as Int64)
    v0 = (5000000000 as Int64)
    var v1: Double = (0.0 as Double)
    v1 = (1.5 as Double)
    var v2: Heap0 = Heap0(l0: (0 as Int64), l1: (0.0 as Double))
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int64 = (0 as Int64)
    var v4: Double = (0.0 as Double)
    v3 = v2.l0
    v4 = v2.l1
    var v5: Bool = false
    v5 = (v3 == (5000000000 as Int64))
    var v7: Bool = false
    if (v5) {
        var v6: Bool = false
        v6 = (v4 == (1.5 as Double))
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
