import CRT
class Heap0 {
    let l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: Array<Heap0> = Array<Heap0>()
    v1 = Array<Heap0>(repeating: Heap0(l0: 0), count: Int(v0))
    var v2: Int32 = 0
    v2 = 4
    var v3: Int32 = 0
    v3 = 6
    var v4: Heap0 = Heap0(l0: 0)
    v4 = Heap0(l0: v2)
    v1[Int(0)] = v4
    var v5: Heap0 = Heap0(l0: 0)
    v5 = Heap0(l0: v3)
    v1[Int(1)] = v5
    var v6: Heap0 = Heap0(l0: 0)
    v6 = v1[Int(0)]
    var v7: Int32 = 0
    v7 = v6.l0
    var v8: Heap0 = Heap0(l0: 0)
    v8 = v1[Int(1)]
    var v9: Int32 = 0
    v9 = v8.l0
    var v10: Int32 = 0
    v10 = (v7 &+ v9)
    var v11: Bool = false
    v11 = (v10 == 10)
    if (v11) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
