import CRT
func sp_method0(_ p0: Float) -> (Bool, Float, Int32) {
    var v0: Float = p0
    var v1: Bool = false
    v1 = (v0 >= (3.5 as Float))
    return (v1, v0, 7)
}
func sp_method1(_ p0: Bool, _ p1: Float, _ p2: Int32) -> Int32 {
    var v0: Bool = p0
    var v1: Float = p1
    var v2: Int32 = p2
    if (v0) {
        var v3: Bool = false
        v3 = (v1 >= (3.5 as Float))
        if (v3) {
            var v4: Int32 = 0
            v4 = (v2 &- 7)
            return v4
        } else {
            return 1
        }
    } else {
        return 2
    }
}
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (4.0 as Float)
    var v1: Bool = false
    var v2: Float = (0.0 as Float)
    var v3: Int32 = 0
    let spiral_tuple177 = sp_method0(v0)
    v1 = spiral_tuple177.0
    v2 = spiral_tuple177.1
    v3 = spiral_tuple177.2
    return sp_method1(v1, v2, v3)
}
exit(spiral_main())
