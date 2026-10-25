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
    let l1: Heap0
    let l2: Heap0
    init(l0: Heap0, l1: Heap0, l2: Heap0) {
        self.l0 = l0
        self.l1 = l1
        self.l2 = l2
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(l0: 0, l1: "")
    v5 = Heap0(l0: v3, l1: v4)
    var v6: Int32 = 0
    v6 = 9
    var v7: String = ""
    v7 = "ok"
    var v8: Heap0 = Heap0(l0: 0, l1: "")
    v8 = Heap0(l0: v6, l1: v7)
    var v9: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""), l2: Heap0(l0: 0, l1: ""))
    v9 = Heap1(l0: v2, l1: v5, l2: v8)
    var v10: Heap0 = Heap0(l0: 0, l1: "")
    var v11: Heap0 = Heap0(l0: 0, l1: "")
    var v12: Heap0 = Heap0(l0: 0, l1: "")
    v10 = v9.l0
    v11 = v9.l1
    v12 = v9.l2
    var v13: Int32 = 0
    var v14: String = ""
    v13 = v10.l0
    v14 = v10.l1
    var v15: Int32 = 0
    var v16: String = ""
    v15 = v11.l0
    v16 = v11.l1
    var v17: Int32 = 0
    var v18: String = ""
    v17 = v12.l0
    v18 = v12.l1
    var v19: Bool = false
    v19 = (v13 == 7)
    var v21: Bool = false
    if (v19) {
        var v20: Bool = false
        v20 = (v14 == "hi")
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Bool = false
    if (v21) {
        var v22: Bool = false
        v22 = (v15 == 4)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        var v24: Bool = false
        v24 = (v16 == "yo")
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Bool = false
    if (v25) {
        var v26: Bool = false
        v26 = (v17 == 9)
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Bool = false
    if (v27) {
        var v28: Bool = false
        v28 = (v18 == "ok")
        v29 = v28
    } else {
        v29 = false
    }
    if (v29) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
