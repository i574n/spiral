import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func sp_method0(_ p0: Heap0, _ p1: Heap0) -> (Heap0, Heap0) {
    var v0: Heap0 = p0
    var v1: Heap0 = p1
    return (v0, v1)
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: Heap0 = Heap0(l0: 0)
    v2 = Heap0(l0: v0)
    var v3: Heap0 = Heap0(l0: 0)
    v3 = Heap0(l0: v1)
    var v4: Heap0 = Heap0(l0: 0)
    var v5: Heap0 = Heap0(l0: 0)
    let spiral_tuple285 = sp_method0(v2, v3)
    v4 = spiral_tuple285.0
    v5 = spiral_tuple285.1
    var v6: Int32 = 0
    v6 = v4.l0
    var v7: Int32 = 0
    v7 = v5.l0
    var v8: Int32 = 0
    v8 = (v6 &+ v7)
    var v9: Bool = false
    v9 = (v8 == 7)
    if (v9) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
