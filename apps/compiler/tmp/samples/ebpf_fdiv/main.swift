import CRT
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (1.5 as Float)
    var v1: Float = (0.0 as Float)
    v1 = (-2.0 as Float)
    var v2: Float = (0.0 as Float)
    v2 = (-0.5 as Float)
    var v3: Float = (0.0 as Float)
    v3 = (v0 / v1)
    var v4: Float = (0.0 as Float)
    v4 = (v2 / v1)
    var v5: Bool = false
    v5 = (v3 == (-0.75 as Float))
    var v7: Bool = false
    if (v5) {
        var v6: Bool = false
        v6 = (v4 == (0.25 as Float))
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
