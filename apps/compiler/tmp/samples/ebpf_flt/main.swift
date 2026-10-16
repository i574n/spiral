import CRT
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (-2.0 as Float)
    var v1: Float = (0.0 as Float)
    v1 = (-1.0 as Float)
    var v2: Float = (0.0 as Float)
    v2 = (0.0 as Float)
    var v3: Bool = false
    v3 = (v0 < v1)
    var v5: Bool = false
    if (v3) {
        var v4: Bool = false
        v4 = (v1 < v2)
        v5 = v4
    } else {
        v5 = false
    }
    var v8: Bool = false
    if (v5) {
        var v6: Bool = false
        v6 = (v0 > v1)
        var v7: Bool = false
        v7 = (v6 == false)
        v8 = v7
    } else {
        v8 = false
    }
    var v11: Bool = false
    if (v8) {
        var v9: Bool = false
        v9 = (v0 >= v1)
        var v10: Bool = false
        v10 = (v9 == false)
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Bool = false
    if (v11) {
        var v12: Bool = false
        v12 = (v1 <= v2)
        v13 = v12
    } else {
        v13 = false
    }
    if (v13) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
