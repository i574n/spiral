sealed interface US1 { val tag: Int }
data class US1_A(val f0: Int) : US1 { override val tag: Int = 0 }
data class US1_B(val f0: Int) : US1 { override val tag: Int = 1 }
sealed interface US0 { val tag: Int }
data class US0_Wrap(val f0: US1) : US0 { override val tag: Int = 0 }
data class US0_Other(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_score_inner_1(p0: US1): Int {
    var v0: US1 = p0
    when (v0.tag) {
        0 -> {
            var v1: Int = (v0 as US1_A).f0
            return v1
        }
        1 -> {
            var v2: Int = (v0 as US1_B).f0
            val v3: Int = (-(v2))
            return v3
        }
        else -> throw RuntimeException()
    }
}
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v3: Int = (v0 as US0_Other).f0
            return v3
        }
        0 -> {
            var v1: US1 = (v0 as US0_Wrap).f0
            return sp_score_inner_1(v1)
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Boolean = true
    var v4: US0 = US0_Wrap(US1_A(0))
    if (v0) {
        val v1: US1 = US1_A(7)
        v4 = US0_Wrap(v1)
    } else {
        v4 = US0_Other(1)
    }
    var v8: US0 = US0_Wrap(US1_A(0))
    if (v0) {
        v8 = US0_Other(4)
    } else {
        val v6: US1 = US1_B(2)
        v8 = US0_Wrap(v6)
    }
    val v9: Int = sp_score_0(v4)
    val v10: Boolean = (v9 == 7)
    var v13: Boolean = false
    if (v10) {
        val v11: Int = sp_score_0(v8)
        val v12: Boolean = (v11 == 4)
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
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
