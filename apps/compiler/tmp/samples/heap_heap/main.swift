import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    let l1: String
    init(l0: Int32, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
class Heap1 {
    let l0: Heap0
    let l1: Int32
    init(l0: Heap0, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: String = "hi"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 1
    let v4: Heap1 = Heap1(l0: v2, l1: v3)
    var v5: Heap0 = Heap0(l0: 0, l1: "")
    var v6: Int32 = 0
    v5 = v4.l0
    v6 = v4.l1
    var v7: Int32 = 0
    var v8: String = ""
    v7 = v5.l0
    v8 = v5.l1
    let v9: Bool = (v7 == 7)
    var v11: Bool = false
    if (v9) {
        let v10: Bool = (v8 == "hi")
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Bool = false
    if (v11) {
        let v12: Bool = (v6 == 1)
        v13 = v12
    } else {
        v13 = false
    }
    if (v13) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
