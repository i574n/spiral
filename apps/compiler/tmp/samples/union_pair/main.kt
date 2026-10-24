sealed interface US0 { val tag: Int }
data class US0_One(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Both(val f0: Int, val f1: Int) : US0 { override val tag: Int = 1 }
fun sp_sum_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v2: Int = (v0 as US0_Both).f0
            var v3: Int = (v0 as US0_Both).f1
            val v4: Int = (v2 * 10)
            val v5: Int = (v4 + v3)
            return v5
        }
        0 -> {
            var v1: Int = (v0 as US0_One).f0
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Boolean = true
    var v3: US0 = US0_One(0)
    if (v0) {
        v3 = US0_Both(3, 4)
    } else {
        v3 = US0_One(1)
    }
    var v6: US0 = US0_One(0)
    if (v0) {
        v6 = US0_One(5)
    } else {
        v6 = US0_Both(1, 1)
    }
    val v7: Int = sp_sum_0(v3)
    val v8: Boolean = (v7 == 34)
    var v11: Boolean = false
    if (v8) {
        val v9: Int = sp_sum_0(v6)
        val v10: Boolean = (v9 == 5)
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
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
