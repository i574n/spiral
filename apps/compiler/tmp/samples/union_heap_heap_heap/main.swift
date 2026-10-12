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
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap2; var tag: Int32 { 1 } }
func sp_score_0(_ p0: US0) -> Int32 {
    var v0: US0 = p0
    switch v0.tag {
        case 1:
            var v1: Heap2 = (v0 as! US0_Held).f0
            var v2: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
            var v3: Int32 = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Heap0 = Heap0(l0: 0, l1: "")
            var v5: Int32 = 0
            v4 = v2.l0
            v5 = v2.l1
            var v6: Int32 = 0
            var v7: String = ""
            v6 = v4.l0
            v7 = v4.l1
            var v8: Bool = false
            v8 = (v6 == 7)
            var v10: Bool = false
            if (v8) {
                var v9: Bool = false
                v9 = (v7 == "hi")
                v10 = v9
            } else {
                v10 = false
            }
            var v12: Bool = false
            if (v10) {
                var v11: Bool = false
                v11 = (v5 == 1)
                v12 = v11
            } else {
                v12 = false
            }
            var v14: Bool = false
            if (v12) {
                var v13: Bool = false
                v13 = (v3 == 2)
                v14 = v13
            } else {
                v14 = false
            }
            if (v14) {
                return 0
            } else {
                return 1
            }
        case 0:
            return 1
        default:
            fatalError("unreachable union case")
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
    var v5: Int32 = 0
    v5 = 2
    var v6: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0), l1: 0)
    v6 = Heap2(l0: v4, l1: v5)
    var v7: Bool = false
    v7 = true
    var v10: US0 = US0_None()
    if (v7) {
        v10 = US0_Held(f0: v6)
    } else {
        v10 = US0_None()
    }
    return sp_score_0(v10)
}
exit(spiral_main())
