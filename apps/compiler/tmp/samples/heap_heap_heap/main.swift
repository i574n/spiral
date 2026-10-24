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
class Heap2 {
    let l0: Heap1
    let l1: Int32
    init(l0: Heap1, l1: Int32) {
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
    let v5: Int32 = 2
    let v6: Heap2 = Heap2(l0: v4, l1: v5)
    var v7: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    var v8: Int32 = 0
    v7 = v6.l0
    v8 = v6.l1
    var v9: Heap0 = Heap0(l0: 0, l1: "")
    var v10: Int32 = 0
    v9 = v7.l0
    v10 = v7.l1
    var v11: Int32 = 0
    var v12: String = ""
    v11 = v9.l0
    v12 = v9.l1
    let v13: Bool = (v11 == 7)
    var v15: Bool = false
    if (v13) {
        let v14: Bool = (v12 == "hi")
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Bool = false
    if (v15) {
        let v16: Bool = (v10 == 1)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Bool = false
    if (v17) {
        let v18: Bool = (v8 == 2)
        v19 = v18
    } else {
        v19 = false
    }
    if (v19) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
