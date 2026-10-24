import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func sp_method0(_ p0: Int32, _ p1: Heap0) -> (Heap0, Int32) {
    var v0: Int32 = p0
    var v1: Heap0 = p1
    return (v1, v0)
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 4
    let v2: Heap0 = Heap0(l0: v0)
    var v3: Heap0 = Heap0(l0: 0)
    var v4: Int32 = 0
    let spiral_tuple216 = sp_method0(v1, v2)
    v3 = spiral_tuple216.0
    v4 = spiral_tuple216.1
    let v5: Int32 = v3.l0
    let v6: Int32 = (v5 &+ v4)
    let v7: Bool = (v6 == 7)
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
