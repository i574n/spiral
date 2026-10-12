import CRT
class Heap0 {
    let l0: Int32
    let l1: Int32
    init(l0: Int32, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: Heap0 = Heap0(l0: 0, l1: 0)
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    var v4: Int32 = 0
    v3 = v2.l0
    v4 = v2.l1
    var v5: Int32 = 0
    v5 = (v3 &+ v4)
    var v6: Bool = false
    v6 = (v5 == 7)
    if (v6) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
