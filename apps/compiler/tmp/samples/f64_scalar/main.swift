import CRT
func spiral_main() -> Int32 {
    var v0: Double = (0.0 as Double)
    v0 = (1.5 as Double)
    var v1: Double = (0.0 as Double)
    v1 = (-2.0 as Double)
    var v2: Double = (0.0 as Double)
    v2 = (v0 / v1)
    var v3: Double = (0.0 as Double)
    v3 = (1000000.0 as Double)
    var v4: Double = (0.0 as Double)
    v4 = (v3 * v3)
    var v5: Double = (0.0 as Double)
    v5 = (v4 * v3)
    var v6: Double = (0.0 as Double)
    v6 = (v5 * (10000.0 as Double))
    var v7: Double = (0.0 as Double)
    v7 = (v6 * v6)
    var v8: Int32 = 0
    v8 = 3
    var v9: Double = (0.0 as Double)
    v9 = Double(v8)
    var v10: Double = (0.0 as Double)
    v10 = (2.9 as Double)
    var v11: Double = (0.0 as Double)
    v11 = (-1.9 as Double)
    var v12: Int32 = 0
    v12 = Int32(v10)
    var v13: Int32 = 0
    v13 = Int32(v11)
    var v14: Float = (0.0 as Float)
    v14 = (1.5 as Float)
    var v15: Double = (0.0 as Double)
    v15 = Double(v14)
    var v16: Bool = false
    v16 = (v2 == (-0.75 as Double))
    var v18: Bool = false
    if (v16) {
        var v17: Bool = false
        v17 = (v7 > v6)
        v18 = v17
    } else {
        v18 = false
    }
    var v21: Bool = false
    if (v18) {
        var v19: Double = (0.0 as Double)
        v19 = (v7 * v6)
        var v20: Bool = false
        v20 = (v7 < v19)
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Bool = false
    if (v21) {
        var v22: Bool = false
        v22 = (v9 == (3.0 as Double))
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        var v24: Bool = false
        v24 = (v12 == 2)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Bool = false
    if (v25) {
        var v26: Bool = false
        v26 = (v13 == -1)
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Bool = false
    if (v27) {
        var v28: Bool = false
        v28 = (v15 == (1.5 as Double))
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
exit(spiral_main())
