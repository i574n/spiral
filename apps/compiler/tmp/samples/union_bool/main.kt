sealed interface US0 { val tag: Int }
data class US0_No(val f0: Boolean) : US0 { override val tag: Int = 0 }
data class US0_Yes(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            var v1: Boolean = (v0 as US0_No).f0
            if (v1) {
                return 1
            } else {
                return 2
            }
        }
        1 -> {
            var v3: Int = (v0 as US0_Yes).f0
            return v3
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v3: US0 = US0_No(false)
    if (v0) {
        v3 = US0_Yes(7)
    } else {
        v3 = US0_No(false)
    }
    var v6: US0 = US0_No(false)
    if (v0) {
        v6 = US0_No(true)
    } else {
        v6 = US0_Yes(1)
    }
    var v7: Int = 0
    v7 = sp_score_0(v3)
    var v8: Boolean = false
    v8 = (v7 == 7)
    var v11: Boolean = false
    if (v8) {
        var v9: Int = 0
        v9 = sp_score_0(v6)
        var v10: Boolean = false
        v10 = (v9 == 1)
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
