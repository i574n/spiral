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
class Mut1 {
    var l0: Heap0
    var l1: Heap0
    var l2: Heap0
    init(l0: Heap0, l1: Heap0, l2: Heap0) {
        self.l0 = l0
        self.l1 = l1
        self.l2 = l2
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 1
    let v1: String = "no"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 2
    let v4: String = "zz"
    let v5: Heap0 = Heap0(l0: v3, l1: v4)
    let v6: Int32 = 3
    let v7: String = "aa"
    let v8: Heap0 = Heap0(l0: v6, l1: v7)
    var v9: Mut1 = Mut1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""), l2: Heap0(l0: 0, l1: ""))
    v9 = Mut1(l0: v2, l1: v5, l2: v8)
    let v10: Int32 = 7
    let v11: String = "hi"
    let v12: Heap0 = Heap0(l0: v10, l1: v11)
    let v13: Int32 = 4
    let v14: String = "yo"
    let v15: Heap0 = Heap0(l0: v13, l1: v14)
    let v16: Int32 = 9
    let v17: String = "ok"
    let v18: Heap0 = Heap0(l0: v16, l1: v17)
    v9.l0 = v12
    v9.l1 = v15
    v9.l2 = v18
    var v19: Heap0 = Heap0(l0: 0, l1: "")
    var v20: Heap0 = Heap0(l0: 0, l1: "")
    var v21: Heap0 = Heap0(l0: 0, l1: "")
    v19 = v9.l0
    v20 = v9.l1
    v21 = v9.l2
    var v22: Int32 = 0
    var v23: String = ""
    v22 = v19.l0
    v23 = v19.l1
    var v24: Int32 = 0
    var v25: String = ""
    v24 = v20.l0
    v25 = v20.l1
    var v26: Int32 = 0
    var v27: String = ""
    v26 = v21.l0
    v27 = v21.l1
    let v28: Bool = (v22 == 7)
    var v30: Bool = false
    if (v28) {
        let v29: Bool = (v23 == "hi")
        v30 = v29
    } else {
        v30 = false
    }
    var v32: Bool = false
    if (v30) {
        let v31: Bool = (v24 == 4)
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Bool = false
    if (v32) {
        let v33: Bool = (v25 == "yo")
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Bool = false
    if (v34) {
        let v35: Bool = (v26 == 9)
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Bool = false
    if (v36) {
        let v37: Bool = (v27 == "ok")
        v38 = v37
    } else {
        v38 = false
    }
    if (v38) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
