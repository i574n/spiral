import CRT
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (-1.5 as Float)
    var v1: Float = (0.0 as Float)
    v1 = (2.0 as Float)
    var v2: Float = (0.0 as Float)
    v2 = (v0 / v1)
    var v3: Float = (0.0 as Float)
    v3 = (-0.75 as Float)
    var v4: Float = (0.0 as Float)
    v4 = (v0 * v1)
    var v5: Float = (0.0 as Float)
    v5 = (v4 + (0.5 as Float))
    var v6: Float = (0.0 as Float)
    v6 = (-2.5 as Float)
    var v7: Bool = false
    v7 = (v2 == v3)
    if (v7) {
        var v8: Bool = false
        v8 = (v5 == v6)
        if (v8) {
            return 0
        } else {
            return 2
        }
    } else {
        return 1
    }
}
exit(spiral_main())
