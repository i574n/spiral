import CRT
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func sp_method0(_ p0: Heap0) -> Heap0 {
    var v0: Heap0 = p0
    return v0
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Heap0 = Heap0(l0: 0)
    v1 = Heap0(l0: v0)
    var v2: Heap0 = Heap0(l0: 0)
    v2 = sp_method0(v1)
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
