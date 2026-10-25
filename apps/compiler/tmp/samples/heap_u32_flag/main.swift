import CRT
import WinSDK
class Heap0 {
    let l0: UInt32
    let l1: String
    let l2: Bool
    init(l0: UInt32, l1: String, l2: Bool) {
        self.l0 = l0
        self.l1 = l1
        self.l2 = l2
    }
}
func spiral_main() -> Int32 {
    let v0: UInt32 = UInt32(4000000000)
    let v1: String = "hi"
    let v2: Bool = true
    let v3: Heap0 = Heap0(l0: v0, l1: v1, l2: v2)
    var v4: UInt32 = UInt32(0)
    var v5: String = ""
    var v6: Bool = false
    v4 = v3.l0
    v5 = v3.l1
    v6 = v3.l2
    let v7: Bool = (v4 == UInt32(4000000000))
    var v9: Bool = false
    if (v7) {
        let v8: Bool = (v5 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    let v10: Bool = (v9 && v6)
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
