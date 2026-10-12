import CRT
class Mut0 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func sp_method0(_ p0: Mut0) -> Mut0 {
    var v0: Mut0 = p0
    return v0
}
func spiral_main() -> Int32 {
    var v0: Mut0 = Mut0(l0: 0)
    v0 = Mut0(l0: 1)
    var v1: Mut0 = Mut0(l0: 0)
    v1 = sp_method0(v0)
    v1.l0 = 7
    var v2: Int32 = 0
    v2 = v1.l0
    var v3: Bool = false
    v3 = (v2 == 7)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
