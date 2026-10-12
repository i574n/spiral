import CRT
func f_c0(_ v0: Double) -> (Int32) -> Double {
    return { (v1: Int32) -> Double in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            return (0.0 as Double)
        } else {
            return v0
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Double = (0.0 as Double)
    v0 = (1.5 as Double)
    var v1: (Int32) -> Double = { (_: Int32) -> Double in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: Double = (0.0 as Double)
    v2 = v1(1)
    var v3: Bool = false
    v3 = (v2 == (1.5 as Double))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
