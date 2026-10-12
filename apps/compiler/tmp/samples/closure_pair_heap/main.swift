import CRT
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func f_c0(_ v0: Heap0, _ v1: Heap0) -> (Int32) -> (Heap0, Heap0) {
    return { (v2: Int32) -> (Heap0, Heap0) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            return (v1, v0)
        } else {
            return (v0, v1)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: Heap0 = Heap0(l0: 0)
    v2 = Heap0(l0: v0)
    var v3: Heap0 = Heap0(l0: 0)
    v3 = Heap0(l0: v1)
    var v4: (Int32) -> (Heap0, Heap0) = { (_: Int32) -> (Heap0, Heap0) in fatalError("unreachable closure") }
    v4 = f_c0(v2, v3)
    var v5: Heap0 = Heap0(l0: 0)
    var v6: Heap0 = Heap0(l0: 0)
    let spiral_tuple419 = v4(1)
    v5 = spiral_tuple419.0
    v6 = spiral_tuple419.1
    var v7: Int32 = 0
    v7 = v5.l0
    var v8: Int32 = 0
    v8 = v6.l0
    var v9: Int32 = 0
    v9 = (v7 &+ v8)
    var v10: Bool = false
    v10 = (v9 == 7)
    if (v10) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
