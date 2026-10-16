fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = Float.POSITIVE_INFINITY
    var v1: Double = 0.0
    v1 = Double.POSITIVE_INFINITY
    var v2: Float = 0.0f
    v2 = (-(v0))
    var v3: Double = 0.0
    v3 = (-(v1))
    var v4: Float = 0.0f
    v4 = 1.0f
    var v5: Double = 0.0
    v5 = 1.0
    var v6: Boolean = false
    v6 = (v4 != v4)
    var v8: Boolean = false
    if (v6) {
        v8 = true
    } else {
        var v7: Boolean = false
        v7 = (v5 != v5)
        v8 = v7
    }
    if (v8) {
        return 3
    } else {
        var v9: Boolean = false
        v9 = (v0 > v4)
        var v11: Boolean = false
        if (v9) {
            var v10: Boolean = false
            v10 = (v1 > v5)
            v11 = v10
        } else {
            v11 = false
        }
        if (v11) {
            var v12: Boolean = false
            v12 = (v2 < 0.0f)
            var v14: Boolean = false
            if (v12) {
                var v13: Boolean = false
                v13 = (v3 < 0.0)
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
fun main() {
    System.exit(spiral_main())
}
