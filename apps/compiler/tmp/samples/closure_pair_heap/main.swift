import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func f_c0(_ v0: Heap0, _ v1: Heap0) -> (Int32) -> (Heap0, Heap0) {
    return { (v2: Int32) -> (Heap0, Heap0) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            return (v1, v0)
        } else {
            return (v0, v1)
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 4
    let v2: Heap0 = Heap0(l0: v0)
    var v3: Heap0 = Heap0(l0: 0)
    v3 = Heap0(l0: v1)
    let v4: (Int32) -> (Heap0, Heap0) = f_c0(v2, v3)
    var v5: Heap0 = Heap0(l0: 0)
    var v6: Heap0 = Heap0(l0: 0)
    let spiral_tuple419 = v4(1)
    v5 = spiral_tuple419.0
    v6 = spiral_tuple419.1
    let v7: Int32 = v5.l0
    let v8: Int32 = v6.l0
    let v9: Int32 = (v7 &+ v8)
    let v10: Bool = (v9 == 7)
    if (v10) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
