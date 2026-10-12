import CRT
func sp_method0(_ p0: Int32) -> Double {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        return (0.0 as Double)
    } else {
        return (1.5 as Double)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Double = (0.0 as Double)
    v1 = sp_method0(v0)
    var v2: Bool = false
    v2 = (v1 == (1.5 as Double))
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
