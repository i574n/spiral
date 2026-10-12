import CRT
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
class Heap1 {
    let l0: Heap0
    init(l0: Heap0) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Heap0 = Heap0(l0: 0)
    v1 = Heap0(l0: v0)
    var v2: Heap1 = Heap1(l0: Heap0(l0: 0))
    v2 = Heap1(l0: v1)
    var v3: Heap0 = Heap0(l0: 0)
    v3 = v2.l0
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
