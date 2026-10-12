import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: Array<Double> = Array<Double>()
    v1 = Array<Double>(repeating: (0.0 as Double), count: Int(v0))
    var v2: Double = (0.0 as Double)
    v2 = (1.5 as Double)
    v1[Int(0)] = v2
    v1[Int(1)] = (2.5 as Double)
    var v3: Double = (0.0 as Double)
    v3 = v1[Int(0)]
    var v4: Bool = false
    v4 = (v3 == (1.5 as Double))
    if (v4) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
