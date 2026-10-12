import CRT
class Heap0 {
    let l0: Array<Double>
    init(l0: Array<Double>) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Array<Double> = Array<Double>()
    v0 = Array<Double>(repeating: (0.0 as Double), count: Int(1))
    var v1: Double = (0.0 as Double)
    v1 = (1.5 as Double)
    v0[Int(0)] = v1
    var v2: Heap0 = Heap0(l0: Array<Double>())
    v2 = Heap0(l0: v0)
    var v3: Array<Double> = Array<Double>()
    v3 = v2.l0
    var v4: Double = (0.0 as Double)
    v4 = v3[Int(0)]
    var v5: Bool = false
    v5 = (v4 == (1.5 as Double))
    if (v5) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
