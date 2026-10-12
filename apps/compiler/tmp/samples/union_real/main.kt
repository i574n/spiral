sealed interface US0 { val tag: Int }
data class US0_Real(val f0: Double) : US0 { override val tag: Int = 0 }
data class US0_Whole(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_twice_1(p0: Double): Int {
    var v0: Double = p0
    var v1: Double = 0.0
    v1 = (v0 * 2.0)
    var v2: Int = 0
    v2 = (v1).toInt()
    return v2
}
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            var v1: Double = (v0 as US0_Real).f0
            return sp_twice_1(v1)
        }
        1 -> {
            var v3: Int = (v0 as US0_Whole).f0
            return v3
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v1: Double = 0.0
    v1 = 1.5
    var v4: US0 = US0_Real(0.0)
    if (v0) {
        v4 = US0_Real(v1)
    } else {
        v4 = US0_Whole(1)
    }
    var v7: US0 = US0_Real(0.0)
    if (v0) {
        v7 = US0_Whole(5)
    } else {
        v7 = US0_Real(v1)
    }
    var v8: Int = 0
    v8 = sp_score_0(v4)
    var v9: Boolean = false
    v9 = (v8 == 3)
    var v12: Boolean = false
    if (v9) {
        var v10: Int = 0
        v10 = sp_score_0(v7)
        var v11: Boolean = false
        v11 = (v10 == 5)
        v12 = v11
    } else {
        v12 = false
    }
    if (v12) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
