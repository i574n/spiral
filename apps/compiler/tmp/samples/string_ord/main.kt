fun spiral_main(): Int {
    var v0: String = ""
    v0 = "a"
    var v1: String = ""
    v1 = "b"
    var v2: String = ""
    v2 = "é"
    var v3: String = ""
    v3 = "éx"
    var v4: String = ""
    v4 = ""
    var v5: Boolean = false
    v5 = (v0 < v0)
    if (v5) {
        return 1
    } else {
        var v6: Boolean = false
        v6 = (v0 < v1)
        var v8: Boolean = false
        if (v6) {
            var v7: Boolean = false
            v7 = (v1 < v2)
            v8 = v7
        } else {
            v8 = false
        }
        var v10: Boolean = false
        if (v8) {
            var v9: Boolean = false
            v9 = (v2 < v3)
            v10 = v9
        } else {
            v10 = false
        }
        var v12: Boolean = false
        if (v10) {
            var v11: Boolean = false
            v11 = (v4 < v0)
            v12 = v11
        } else {
            v12 = false
        }
        var v14: Boolean = false
        if (v12) {
            var v13: Boolean = false
            v13 = (v0 <= v0)
            v14 = v13
        } else {
            v14 = false
        }
        var v16: Boolean = false
        if (v14) {
            var v15: Boolean = false
            v15 = (v0 >= v0)
            v16 = v15
        } else {
            v16 = false
        }
        var v18: Boolean = false
        if (v16) {
            var v17: Boolean = false
            v17 = (v3 > v2)
            v18 = v17
        } else {
            v18 = false
        }
        var v20: Boolean = false
        if (v18) {
            var v19: Boolean = false
            v19 = (v1 >= v0)
            v20 = v19
        } else {
            v20 = false
        }
        if (v20) {
            return 0
        } else {
            return 1
        }
    }
}
fun main() {
    System.exit(spiral_main())
}
