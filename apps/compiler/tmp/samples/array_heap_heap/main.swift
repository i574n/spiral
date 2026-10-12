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
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 1
    var v4: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v4 = Heap1(l0: v2, l1: v3)
    var v5: Array<Heap1> = Array<Heap1>()
    v5 = Array<Heap1>(repeating: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0), count: Int(1))
    v5[Int(0)] = v4
    var v6: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v6 = v5[Int(0)]
    var v7: Heap0 = Heap0(l0: 0, l1: "")
    var v8: Int32 = 0
    v7 = v6.l0
    v8 = v6.l1
    var v9: Int32 = 0
    var v10: String = ""
    v9 = v7.l0
    v10 = v7.l1
    var v11: Bool = false
    v11 = (v9 == 7)
    var v13: Bool = false
    if (v11) {
        var v12: Bool = false
        v12 = (v10 == "hi")
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Bool = false
    if (v13) {
        var v14: Bool = false
        v14 = (v8 == 1)
        v15 = v14
    } else {
        v15 = false
    }
    if (v15) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
