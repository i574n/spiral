fun sp_method0(p0: Boolean): Int {
    var v0: Boolean = p0
    if (v0) {
        return 1
    } else {
        return 3
    }
}
fun sp_method1(p0: Boolean, p1: Boolean): Int {
    var v0: Boolean = p0
    var v1: Boolean = p1
    var v2: Boolean = false
    v2 = (v0 && v1)
    if (v2) {
        return 1
    } else {
        var v3: Boolean = false
        v3 = (v0 || v1)
        if (v3) {
            return 2
        } else {
            return 3
        }
    }
}
fun sp_method2(p0: Boolean): Int {
    var v0: Boolean = p0
    if (v0) {
        return 1
    } else {
        return 3
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v1: Boolean = false
    v1 = false
    var v2: Int = 0
    v2 = sp_method0(v0)
    var v3: Int = 0
    v3 = sp_method1(v0, v1)
    var v4: Int = 0
    v4 = sp_method2(v1)
    var v5: Boolean = false
    v5 = (v0 == v1)
    var v6: Boolean = false
    v6 = (v5 == false)
    var v7: Boolean = false
    v7 = (v2 == 1)
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v3 == 2)
        v9 = v8
    } else {
        v9 = false
    }
    var v11: Boolean = false
    if (v9) {
        var v10: Boolean = false
        v10 = (v4 == 3)
        v11 = v10
    } else {
        v11 = false
    }
    var v12: Boolean = false
    v12 = (v11 && v6)
    if (v12) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
