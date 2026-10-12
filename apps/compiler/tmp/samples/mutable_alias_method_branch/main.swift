import CRT
class Mut0 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func sp_method0(_ p0: Mut0) {
    var v0: Mut0 = p0
    var v1: Int32 = 0
    v1 = v0.l0
    var v2: Int32 = 0
    v2 = (v1 &+ 5)
    v0.l0 = v2
}
func sp_method1(_ p0: Mut0) {
    var v0: Mut0 = p0
}
func sp_method2(_ p0: Mut0) {
    var v0: Mut0 = p0
    var v1: Int32 = 0
    v1 = v0.l0
    var v2: Int32 = 0
    v2 = (v1 &+ 7)
    v0.l0 = v2
}
func spiral_main() -> Int32 {
    var v0: Mut0 = Mut0(l0: 0)
    v0 = Mut0(l0: 0)
    sp_method0(v0)
    sp_method1(v0)
    sp_method2(v0)
    var v1: Int32 = 0
    v1 = v0.l0
    var v2: Int32 = 0
    v2 = (v1 &- 12)
    return v2
}
exit(spiral_main())
