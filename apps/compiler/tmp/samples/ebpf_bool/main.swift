import CRT
func sp_method0(_ p0: Bool) -> Int32 {
    var v0: Bool = p0
    if (v0) {
        return 1
    } else {
        return 3
    }
}
func sp_method1(_ p0: Bool, _ p1: Bool) -> Int32 {
    var v0: Bool = p0
    var v1: Bool = p1
    var v2: Bool = false
    v2 = (v0 && v1)
    if (v2) {
        return 1
    } else {
        var v3: Bool = false
        v3 = (v0 || v1)
        if (v3) {
            return 2
        } else {
            return 3
        }
    }
}
func sp_method2(_ p0: Bool) -> Int32 {
    var v0: Bool = p0
    if (v0) {
        return 1
    } else {
        return 3
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v1: Bool = false
    v1 = false
    var v2: Int32 = 0
    v2 = sp_method0(v0)
    var v3: Int32 = 0
    v3 = sp_method1(v0, v1)
    var v4: Int32 = 0
    v4 = sp_method2(v1)
    var v5: Bool = false
    v5 = (v0 == v1)
    var v6: Bool = false
    v6 = (v5 == false)
    var v7: Bool = false
    v7 = (v2 == 1)
    var v9: Bool = false
    if (v7) {
        var v8: Bool = false
        v8 = (v3 == 2)
        v9 = v8
    } else {
        v9 = false
    }
    var v11: Bool = false
    if (v9) {
        var v10: Bool = false
        v10 = (v4 == 3)
        v11 = v10
    } else {
        v11 = false
    }
    var v12: Bool = false
    v12 = (v11 && v6)
    if (v12) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
