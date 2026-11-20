sealed interface US0 { val tag: Int }
data class US0_Real(val f0: Double) : US0 { override val tag: Int = 0 }
data class US0_Whole(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_twice_1(p0: Double): Int {
    var v0: Double = p0
    var v1: Double = 0.0
    v1 = (v0 * 2.0)
    val v2: Int = (v1).toInt()
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
    val v0: Boolean = true
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
    val v8: Int = sp_score_0(v4)
    val v9: Boolean = (v8 == 3)
    var v12: Boolean = false
    if (v9) {
        val v10: Int = sp_score_0(v7)
        val v11: Boolean = (v10 == 5)
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
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
