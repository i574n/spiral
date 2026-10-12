import CRT
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
class Mut3 {
    var l0: Heap2
    init(l0: Heap2) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: String = ""
    v1 = "no"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 1
    var v4: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v4 = Heap1(l0: v2, l1: v3)
    var v5: Int32 = 0
    v5 = 2
    var v6: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0), l1: 0)
    v6 = Heap2(l0: v4, l1: v5)
    var v7: Mut3 = Mut3(l0: Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0), l1: 0))
    v7 = Mut3(l0: v6)
    var v8: Int32 = 0
    v8 = 7
    var v9: String = ""
    v9 = "hi"
    var v10: Heap0 = Heap0(l0: 0, l1: "")
    v10 = Heap0(l0: v8, l1: v9)
    var v11: Int32 = 0
    v11 = 4
    var v12: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v12 = Heap1(l0: v10, l1: v11)
    var v13: Int32 = 0
    v13 = 5
    var v14: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0), l1: 0)
    v14 = Heap2(l0: v12, l1: v13)
    v7.l0 = v14
    var v15: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0), l1: 0)
    v15 = v7.l0
    var v16: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    var v17: Int32 = 0
    v16 = v15.l0
    v17 = v15.l1
    var v18: Heap0 = Heap0(l0: 0, l1: "")
    var v19: Int32 = 0
    v18 = v16.l0
    v19 = v16.l1
    var v20: Int32 = 0
    var v21: String = ""
    v20 = v18.l0
    v21 = v18.l1
    var v22: Bool = false
    v22 = (v20 == 7)
    var v24: Bool = false
    if (v22) {
        var v23: Bool = false
        v23 = (v21 == "hi")
        v24 = v23
    } else {
        v24 = false
    }
    var v26: Bool = false
    if (v24) {
        var v25: Bool = false
        v25 = (v19 == 4)
        v26 = v25
    } else {
        v26 = false
    }
    var v28: Bool = false
    if (v26) {
        var v27: Bool = false
        v27 = (v17 == 5)
        v28 = v27
    } else {
        v28 = false
    }
    if (v28) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
