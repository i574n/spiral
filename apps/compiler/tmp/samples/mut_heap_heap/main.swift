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
class Mut2 {
    var l0: Heap1
    init(l0: Heap1) {
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
    var v5: Mut2 = Mut2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0))
    v5 = Mut2(l0: v4)
    var v6: Int32 = 0
    v6 = 7
    var v7: String = ""
    v7 = "hi"
    var v8: Heap0 = Heap0(l0: 0, l1: "")
    v8 = Heap0(l0: v6, l1: v7)
    var v9: Int32 = 0
    v9 = 4
    var v10: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v10 = Heap1(l0: v8, l1: v9)
    v5.l0 = v10
    var v11: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v11 = v5.l0
    var v12: Heap0 = Heap0(l0: 0, l1: "")
    var v13: Int32 = 0
    v12 = v11.l0
    v13 = v11.l1
    var v14: Int32 = 0
    var v15: String = ""
    v14 = v12.l0
    v15 = v12.l1
    var v16: Bool = false
    v16 = (v14 == 7)
    var v18: Bool = false
    if (v16) {
        var v17: Bool = false
        v17 = (v15 == "hi")
        v18 = v17
    } else {
        v18 = false
    }
    var v20: Bool = false
    if (v18) {
        var v19: Bool = false
        v19 = (v13 == 4)
        v20 = v19
    } else {
        v20 = false
    }
    if (v20) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
