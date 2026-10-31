import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func f_c0(_ v0: Int32, _ v1: Heap0) -> (Int32) -> (Heap0, Int32) {
    return { (v2: Int32) -> (Heap0, Int32) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            return (v1, 0)
        } else {
            return (v1, v0)
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 4
    let v2: Heap0 = Heap0(l0: v0)
    var v3: (Int32) -> (Heap0, Int32) = { (_: Int32) -> (Heap0, Int32) in fatalError("unreachable closure") }
    v3 = f_c0(v1, v2)
    var v4: Heap0 = Heap0(l0: 0)
    var v5: Int32 = 0
    let spiral_tuple339 = v3(1)
    v4 = spiral_tuple339.0
    v5 = spiral_tuple339.1
    let v6: Int32 = v4.l0
    let v7: Int32 = (v6 &+ v5)
    let v8: Bool = (v7 == 7)
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
