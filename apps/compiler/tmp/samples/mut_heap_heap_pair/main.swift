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
    init(l0: Heap0, l1: Heap0) {
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
class Mut3 {
    var l0: Heap2
    init(l0: Heap2) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    var v1: String = ""
    v1 = "no"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 2
    var v4: String = ""
    v4 = "zz"
    var v5: Heap0 = Heap0(l0: 0, l1: "")
    v5 = Heap0(l0: v3, l1: v4)
    var v6: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v6 = Heap1(l0: v2, l1: v5)
    var v7: Int32 = 0
    v7 = 3
    var v8: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v8 = Heap2(l0: v6, l1: v7)
    var v9: Mut3 = Mut3(l0: Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0))
    v9 = Mut3(l0: v8)
    var v10: Int32 = 0
    v10 = 7
    var v11: String = ""
    v11 = "hi"
    var v12: Heap0 = Heap0(l0: 0, l1: "")
    v12 = Heap0(l0: v10, l1: v11)
    var v13: Int32 = 0
    v13 = 4
    var v14: String = ""
    v14 = "yo"
    var v15: Heap0 = Heap0(l0: 0, l1: "")
    v15 = Heap0(l0: v13, l1: v14)
    var v16: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v16 = Heap1(l0: v12, l1: v15)
    var v17: Int32 = 0
    v17 = 2
    var v18: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v18 = Heap2(l0: v16, l1: v17)
    v9.l0 = v18
    var v19: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v19 = v9.l0
    var v20: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    var v21: Int32 = 0
    v20 = v19.l0
    v21 = v19.l1
    var v22: Heap0 = Heap0(l0: 0, l1: "")
    var v23: Heap0 = Heap0(l0: 0, l1: "")
    v22 = v20.l0
    v23 = v20.l1
    var v24: Int32 = 0
    var v25: String = ""
    v24 = v22.l0
    v25 = v22.l1
    var v26: Int32 = 0
    var v27: String = ""
    v26 = v23.l0
    v27 = v23.l1
    var v28: Bool = false
    v28 = (v24 == 7)
    var v30: Bool = false
    if (v28) {
        var v29: Bool = false
        v29 = (v25 == "hi")
        v30 = v29
    } else {
        v30 = false
    }
    var v32: Bool = false
    if (v30) {
        var v31: Bool = false
        v31 = (v26 == 4)
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Bool = false
    if (v32) {
        var v33: Bool = false
        v33 = (v27 == "yo")
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Bool = false
    if (v34) {
        var v35: Bool = false
        v35 = (v21 == 2)
        v36 = v35
    } else {
        v36 = false
    }
    if (v36) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
