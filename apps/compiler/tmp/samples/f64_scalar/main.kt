fun spiral_main(): Int {
    var v0: Double = 0.0
    v0 = 1.5
    var v1: Double = 0.0
    v1 = -2.0
    var v2: Double = 0.0
    v2 = (v0 / v1)
    var v3: Double = 0.0
    v3 = 1000000.0
    var v4: Double = 0.0
    v4 = (v3 * v3)
    var v5: Double = 0.0
    v5 = (v4 * v3)
    var v6: Double = 0.0
    v6 = (v5 * 10000.0)
    var v7: Double = 0.0
    v7 = (v6 * v6)
    var v8: Int = 0
    v8 = 3
    var v9: Double = 0.0
    v9 = (v8).toDouble()
    var v10: Double = 0.0
    v10 = 2.9
    var v11: Double = 0.0
    v11 = -1.9
    var v12: Int = 0
    v12 = (v10).toInt()
    var v13: Int = 0
    v13 = (v11).toInt()
    var v14: Float = 0.0f
    v14 = 1.5f
    var v15: Double = 0.0
    v15 = (v14).toDouble()
    var v16: Boolean = false
    v16 = (v2 == -0.75)
    var v18: Boolean = false
    if (v16) {
        var v17: Boolean = false
        v17 = (v7 > v6)
        v18 = v17
    } else {
        v18 = false
    }
    var v21: Boolean = false
    if (v18) {
        var v19: Double = 0.0
        v19 = (v7 * v6)
        var v20: Boolean = false
        v20 = (v7 < v19)
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Boolean = false
    if (v21) {
        var v22: Boolean = false
        v22 = (v9 == 3.0)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        var v24: Boolean = false
        v24 = (v12 == 2)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        var v26: Boolean = false
        v26 = (v13 == -1)
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        var v28: Boolean = false
        v28 = (v15 == 1.5)
        v29 = v28
    } else {
        v29 = false
    }
    if (v29) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
