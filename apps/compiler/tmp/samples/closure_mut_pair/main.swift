import CRT
class Mut0 {
    var l0: Int32
    var l1: String
    init(l0: Int32, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func f_c0(_ v0: Mut0) -> (Int32) -> Mut0 {
    return { (v1: Int32) -> Mut0 in
        var v2: Bool = false
        v2 = (v1 == 0)
        return v0
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: String = ""
    v1 = "no"
    var v2: Mut0 = Mut0(l0: 0, l1: "")
    v2 = Mut0(l0: v0, l1: v1)
    var v3: (Int32) -> Mut0 = { (_: Int32) -> Mut0 in fatalError("unreachable closure") }
    v3 = f_c0(v2)
    var v4: Mut0 = Mut0(l0: 0, l1: "")
    v4 = v3(1)
    var v5: Int32 = 0
    v5 = 7
    var v6: String = ""
    v6 = "hi"
    v4.l0 = v5
    v4.l1 = v6
    var v7: Int32 = 0
    var v8: String = ""
    v7 = v4.l0
    v8 = v4.l1
    var v9: Bool = false
    v9 = (v7 == 7)
    var v11: Bool = false
    if (v9) {
        var v10: Bool = false
        v10 = (v8 == "hi")
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
