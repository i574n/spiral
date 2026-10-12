import CRT
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func g_c1(_ v0: Heap0, _ v1: Int32) -> (Int32) -> Int32 {
    return { (v2: Int32) -> Int32 in
        var v3: Int32 = 0
        v3 = v0.l0
        var v4: Bool = false
        v4 = (v1 == 0)
        if (v4) {
            return 0
        } else {
            return v3
        }
    }
}
func f_c0(_ v0: Heap0) -> (Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> (Int32) -> Int32 in
        return g_c1(v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Heap0 = Heap0(l0: 0)
    v1 = Heap0(l0: v0)
    var v2: (Int32) -> (Int32) -> Int32 = { (_: Int32) -> (Int32) -> Int32 in fatalError("unreachable closure") }
    v2 = f_c0(v1)
    var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v3 = v2(1)
    var v4: Int32 = 0
    v4 = v3(0)
    var v5: Bool = false
    v5 = (v4 == 7)
    if (v5) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
