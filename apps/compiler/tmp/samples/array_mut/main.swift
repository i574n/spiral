import CRT
class Mut0 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Array<Mut0> = Array<Mut0>()
    v0 = Array<Mut0>(repeating: Mut0(l0: 0), count: Int(1))
    var v1: Mut0 = Mut0(l0: 0)
    v1 = Mut0(l0: 1)
    v0[Int(0)] = v1
    var v2: Mut0 = Mut0(l0: 0)
    v2 = v0[Int(0)]
    v2.l0 = 7
    var v3: Int32 = 0
    v3 = v2.l0
    var v4: Bool = false
    v4 = (v3 == 7)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
