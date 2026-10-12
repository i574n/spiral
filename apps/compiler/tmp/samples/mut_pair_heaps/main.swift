import CRT
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
    init(l0: Heap0, l1: Heap0) {
        self.l0 = l0
        self.l1 = l1
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
    var v6: Mut1 = Mut1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v6 = Mut1(l0: v2, l1: v5)
    var v7: Int32 = 0
    v7 = 7
    var v8: String = ""
    v8 = "hi"
    var v9: Heap0 = Heap0(l0: 0, l1: "")
    v9 = Heap0(l0: v7, l1: v8)
    var v10: Int32 = 0
    v10 = 4
    var v11: String = ""
    v11 = "yo"
    var v12: Heap0 = Heap0(l0: 0, l1: "")
    v12 = Heap0(l0: v10, l1: v11)
    v6.l0 = v9
    v6.l1 = v12
    var v13: Heap0 = Heap0(l0: 0, l1: "")
    var v14: Heap0 = Heap0(l0: 0, l1: "")
    v13 = v6.l0
    v14 = v6.l1
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
    if (v25) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
