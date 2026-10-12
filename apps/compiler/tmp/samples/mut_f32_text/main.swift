import CRT
class Mut0 {
    var l0: Float
    var l1: String
    init(l0: Float, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (1.5 as Float)
    var v1: String = ""
    v1 = "no"
    var v2: Mut0 = Mut0(l0: (0.0 as Float), l1: "")
    v2 = Mut0(l0: v0, l1: v1)
    var v3: Float = (0.0 as Float)
    v3 = (2.5 as Float)
    var v4: String = ""
    v4 = "hi"
    v2.l0 = v3
    v2.l1 = v4
    var v5: Float = (0.0 as Float)
    var v6: String = ""
    v5 = v2.l0
    v6 = v2.l1
    var v7: Bool = false
    v7 = (v5 == (2.5 as Float))
    var v9: Bool = false
    if (v7) {
        var v8: Bool = false
        v8 = (v6 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
