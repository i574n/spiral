import CRT
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = Float.infinity
    var v1: Double = (0.0 as Double)
    v1 = Double.infinity
    var v2: Float = (0.0 as Float)
    v2 = (-(v0))
    var v3: Double = (0.0 as Double)
    v3 = (-(v1))
    var v4: Float = (0.0 as Float)
    v4 = (1.0 as Float)
    var v5: Double = (0.0 as Double)
    v5 = (1.0 as Double)
    var v6: Bool = false
    v6 = (v4.isNaN)
    var v8: Bool = false
    if (v6) {
        v8 = true
    } else {
        var v7: Bool = false
        v7 = (v5.isNaN)
        v8 = v7
    }
    if (v8) {
        return 3
    } else {
        var v9: Bool = false
        v9 = (v0 > v4)
        var v11: Bool = false
        if (v9) {
            var v10: Bool = false
            v10 = (v1 > v5)
            v11 = v10
        } else {
            v11 = false
        }
        if (v11) {
            var v12: Bool = false
            v12 = (v2 < (0.0 as Float))
            var v14: Bool = false
            if (v12) {
                var v13: Bool = false
                v13 = (v3 < (0.0 as Double))
                v14 = v13
            } else {
                v14 = false
            }
            if (v14) {
                return 0
            } else {
                return 2
            }
        } else {
            return 1
        }
    }
}
exit(spiral_main())
