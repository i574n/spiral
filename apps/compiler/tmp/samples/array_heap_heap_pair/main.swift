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
    var v6: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v6 = Heap1(l0: v2, l1: v5)
    var v7: Int32 = 0
    v7 = 2
    var v8: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v8 = Heap2(l0: v6, l1: v7)
    var v9: Array<Heap2> = Array<Heap2>()
    v9 = Array<Heap2>(repeating: Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0), count: Int(1))
    v9[Int(0)] = v8
    var v10: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v10 = v9[Int(0)]
    var v11: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    var v12: Int32 = 0
    v11 = v10.l0
    v12 = v10.l1
    var v13: Heap0 = Heap0(l0: 0, l1: "")
    var v14: Heap0 = Heap0(l0: 0, l1: "")
    v13 = v11.l0
    v14 = v11.l1
    var v15: Int32 = 0
    var v16: String = ""
    v15 = v13.l0
    v16 = v13.l1
    var v17: Int32 = 0
    var v18: String = ""
    v17 = v14.l0
    v18 = v14.l1
    var v19: Bool = false
    v19 = (v15 == 7)
    var v21: Bool = false
    if (v19) {
        var v20: Bool = false
        v20 = (v16 == "hi")
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Bool = false
    if (v21) {
        var v22: Bool = false
        v22 = (v17 == 4)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        var v24: Bool = false
        v24 = (v18 == "yo")
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Bool = false
    if (v25) {
        var v26: Bool = false
        v26 = (v12 == 2)
        v27 = v26
    } else {
        v27 = false
    }
    if (v27) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
