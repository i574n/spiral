import CRT
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func f_c0(_ v0: Heap0) -> (Int32) -> Heap0 {
    return { (v1: Int32) -> Heap0 in
        return v0
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Heap0 = Heap0(l0: 0)
    v1 = Heap0(l0: v0)
    var v2: (Int32) -> Heap0 = { (_: Int32) -> Heap0 in fatalError("unreachable closure") }
    v2 = f_c0(v1)
    var v3: Heap0 = Heap0(l0: 0)
    v3 = v2(1)
    var v4: Int32 = 0
    v4 = v3.l0
    var v5: Bool = false
    v5 = (v4 == 7)
    if (v5) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
