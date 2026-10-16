import CRT
func sp_method1(_ p0: Int32, _ p1: Float) -> Float {
    var v0: Int32 = p0
    var v1: Float = p1
    while true {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        var v3: Float = (0.0 as Float)
        v3 = (v1 + (1.5 as Float))
        var v4: Bool = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            let t361_2: Int32 = v2
            let t397_3: Float = v3
            v0 = t361_2
            v1 = t397_3
            continue
        }
    }
    return (0.0 as Float)
}
func sp_method0(_ p0: Int32, _ p1: Float) -> Float {
    var v0: Int32 = p0
    var v1: Float = p1
    var v2: Bool = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 4
    var v1: Float = (0.0 as Float)
    v1 = (0.0 as Float)
    var v2: Float = (0.0 as Float)
    v2 = sp_method0(v0, v1)
    var v3: Bool = false
    v3 = (v2 == (6.0 as Float))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
