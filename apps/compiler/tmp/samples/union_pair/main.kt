sealed interface US0 { val tag: Int }
data class US0_One(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Both(val f0: Int, val f1: Int) : US0 { override val tag: Int = 1 }
fun sp_sum_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v2: Int = (v0 as US0_Both).f0
            var v3: Int = (v0 as US0_Both).f1
            var v4: Int = 0
            v4 = (v2 * 10)
            var v5: Int = 0
            v5 = (v4 + v3)
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
    var v0: Boolean = false
    v0 = true
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
    var v7: Int = 0
    v7 = sp_sum_0(v3)
    var v8: Boolean = false
    v8 = (v7 == 34)
    var v11: Boolean = false
    if (v8) {
        var v9: Int = 0
        v9 = sp_sum_0(v6)
        var v10: Boolean = false
        v10 = (v9 == 5)
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
