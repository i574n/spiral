import CRT
import WinSDK
class Heap0 {
    let l0: (Int32) -> Int32
    let l1: Int32
    init(l0: @escaping (Int32) -> Int32, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func add_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: Int32 = 4
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v2 = add_c0(v0)
    let v3: Heap0 = Heap0(l0: v2, l1: v1)
    var v4: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    var v5: Int32 = 0
    v4 = v3.l0
    v5 = v3.l1
    let v6: Int32 = v4(0)
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
