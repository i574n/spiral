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
class Heap3 {
    let l0: US0
    init(l0: US0) {
        self.l0 = l0
    }
}
class Heap4 {
    let l0: US1
    init(l0: US1) {
        self.l0 = l0
    }
}
protocol US0 { var tag: Int32 { get } }
struct US0_None: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Heap2; var tag: Int32 { 1 } }
protocol US1 { var tag: Int32 { get } }
struct US1_Absent: US1 { var tag: Int32 { 0 } }
struct US1_Box: US1 { var f0: Heap3; var tag: Int32 { 1 } }
struct US1_Mark: US1 { var f0: Int32; var tag: Int32 { 2 } }
func f_c0(_ v0: US1, _ v1: Int32) -> (Int32) -> US1 {
    return { (v2: Int32) -> US1 in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            return US1_Absent()
        } else {
            var v5: Bool = false
            v5 = (v2 == 1)
            if (v5) {
                return v0
            } else {
                return US1_Mark(f0: v1)
            }
        }
    }
}
func sp_score_0(_ p0: US1) -> Int32 {
    var v0: US1 = p0
    switch v0.tag {
        case 0:
            return 1
        case 1:
            var v3: Heap3 = (v0 as! US1_Box).f0
            var v4: US0 = US0_None()
            v4 = v3.l0
            switch v4.tag {
                case 1:
                    var v5: Heap2 = (v4 as! US0_Held).f0
                    var v6: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
                    var v7: Int32 = 0
                    v6 = v5.l0
                    v7 = v5.l1
                    var v8: Heap0 = Heap0(l0: 0, l1: "")
                    var v9: Heap0 = Heap0(l0: 0, l1: "")
                    v8 = v6.l0
                    v9 = v6.l1
                    var v10: Int32 = 0
                    var v11: String = ""
                    v10 = v8.l0
                    v11 = v8.l1
                    var v12: Int32 = 0
                    var v13: String = ""
                    v12 = v9.l0
                    v13 = v9.l1
                    var v14: Bool = false
                    v14 = (v10 == 7)
                    var v16: Bool = false
                    if (v14) {
                        var v15: Bool = false
                        v15 = (v11 == "hi")
                        v16 = v15
                    } else {
                        v16 = false
                    }
                    var v18: Bool = false
                    if (v16) {
                        var v17: Bool = false
                        v17 = (v12 == 4)
                        v18 = v17
                    } else {
                        v18 = false
                    }
                    var v20: Bool = false
                    if (v18) {
                        var v19: Bool = false
                        v19 = (v13 == "yo")
                        v20 = v19
                    } else {
                        v20 = false
                    }
                    var v22: Bool = false
                    if (v20) {
                        var v21: Bool = false
                        v21 = (v7 == 2)
                        v22 = v21
                    } else {
                        v22 = false
                    }
                    if (v22) {
                        return 0
                    } else {
                        return 1
                    }
                case 0:
                    return 1
                default:
                    fatalError("unreachable union case")
            }
        case 2:
            var v1: Int32 = (v0 as! US1_Mark).f0
            var v2: Bool = false
            v2 = (v1 == 0)
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
    var v9: Bool = false
    v9 = true
    var v12: US0 = US0_None()
    if (v9) {
        v12 = US0_Held(f0: v8)
    } else {
        v12 = US0_None()
    }
    var v13: Heap3 = Heap3(l0: US0_None())
    v13 = Heap3(l0: v12)
    var v14: Bool = false
    v14 = true
    var v17: US1 = US1_Absent()
    if (v14) {
        v17 = US1_Box(f0: v13)
    } else {
        v17 = US1_Mark(f0: 1)
    }
    var v18: Int32 = 0
    v18 = 3
    var v19: (Int32) -> US1 = { (_: Int32) -> US1 in fatalError("unreachable closure") }
    v19 = f_c0(v17, v18)
    var v20: US1 = US1_Absent()
    v20 = v19(1)
    var v21: Heap4 = Heap4(l0: US1_Absent())
    v21 = Heap4(l0: v20)
    var v22: US1 = US1_Absent()
    v22 = v19(2)
    var v23: Heap4 = Heap4(l0: US1_Absent())
    v23 = Heap4(l0: v22)
    var v24: US1 = US1_Absent()
    v24 = v19(0)
    var v25: Heap4 = Heap4(l0: US1_Absent())
    v25 = Heap4(l0: v24)
    var v26: Array<Heap4> = Array<Heap4>()
    v26 = Array<Heap4>(repeating: Heap4(l0: US1_Absent()), count: Int(3))
    v26[Int(0)] = v21
    v26[Int(1)] = v23
    v26[Int(2)] = v25
    var v27: Heap4 = Heap4(l0: US1_Absent())
    v27 = v26[Int(0)]
    var v28: US1 = US1_Absent()
    v28 = v27.l0
    var v29: Heap4 = Heap4(l0: US1_Absent())
    v29 = v26[Int(1)]
    var v30: US1 = US1_Absent()
    v30 = v29.l0
    var v31: Heap4 = Heap4(l0: US1_Absent())
    v31 = v26[Int(2)]
    var v32: US1 = US1_Absent()
    v32 = v31.l0
    var v33: Int32 = 0
    v33 = sp_score_0(v28)
    var v34: Int32 = 0
    v34 = sp_score_0(v30)
    var v35: Int32 = 0
    v35 = sp_score_0(v32)
    var v36: Bool = false
    v36 = (v33 == 0)
    var v38: Bool = false
    if (v36) {
        var v37: Bool = false
        v37 = (v34 == 1)
        v38 = v37
    } else {
        v38 = false
    }
    var v40: Bool = false
    if (v38) {
        var v39: Bool = false
        v39 = (v35 == 1)
        v40 = v39
    } else {
        v40 = false
    }
    if (v40) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
