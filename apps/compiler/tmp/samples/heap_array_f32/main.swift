import CRT
class Heap0 {
    let l0: Array<Float>
    let l1: Int32
    init(l0: Array<Float>, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Array<Float> = Array<Float>()
    v0 = Array<Float>(repeating: (0.0 as Float), count: Int(1))
    var v1: Float = (0.0 as Float)
    v1 = (1.5 as Float)
    v0[Int(0)] = v1
    var v2: Int32 = 0
    v2 = 7
    var v3: Heap0 = Heap0(l0: Array<Float>(), l1: 0)
    v3 = Heap0(l0: v0, l1: v2)
    var v4: Array<Float> = Array<Float>()
    var v5: Int32 = 0
    v4 = v3.l0
    v5 = v3.l1
    var v6: Float = (0.0 as Float)
    v6 = v4[Int(0)]
    var v7: Bool = false
    v7 = (v6 == (1.5 as Float))
    var v9: Bool = false
    if (v7) {
        var v8: Bool = false
        v8 = (v5 == 7)
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
