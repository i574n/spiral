import CRT
func sp_method0(_ p0: Float, _ p1: Float) -> Float {
    var v0: Float = p0
    var v1: Float = p1
    var v2: Float = (0.0 as Float)
    v2 = (v0 * v1)
    var v3: Float = (0.0 as Float)
    v3 = (v2 + (0.5 as Float))
    return v3
}
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (1.5 as Float)
    var v1: Float = (0.0 as Float)
    v1 = (2.0 as Float)
    var v2: Float = (0.0 as Float)
    v2 = sp_method0(v0, v1)
    var v3: Bool = false
    v3 = (v2 >= (3.5 as Float))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
