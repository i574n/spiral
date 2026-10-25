sealed interface US0 { val tag: Int }
data class US0_Hit(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Miss(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            var v1: Int = (v0 as US0_Hit).f0
            return v1
        }
        1 -> {
            var v2: Int = (v0 as US0_Miss).f0
            var v3: Int = 0
            v3 = (-(v2))
            return v3
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v3: US0 = US0_Hit(0)
    if (v0) {
        v3 = US0_Hit(7)
    } else {
        v3 = US0_Miss(3)
    }
    var v4: Int = 0
    v4 = sp_score_0(v3)
    var v5: Int = 0
    v5 = (v4 - 7)
    return v5
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
