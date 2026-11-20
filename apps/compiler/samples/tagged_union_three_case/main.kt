sealed interface US0 { val tag: Int }
object US0_Idle : US0 { override val tag: Int = 0 }
data class US0_Hit(val f0: Int) : US0 { override val tag: Int = 1 }
data class US0_Flag(val f0: Boolean) : US0 { override val tag: Int = 2 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        2 -> {
            var v2: Boolean = (v0 as US0_Flag).f0
            if (v2) {
                return 11
            } else {
                return 5
            }
        }
        1 -> {
            var v1: Int = (v0 as US0_Hit).f0
            return v1
        }
        0 -> {
            return 3
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Int = 2
    val v1: Boolean = (v0 == 0)
    var v7: US0 = US0_Idle
    if (v1) {
        v7 = US0_Idle
    } else {
        val v3: Boolean = (v0 == 1)
        if (v3) {
            v7 = US0_Hit(7)
        } else {
            v7 = US0_Flag(true)
        }
    }
    val v8: Int = sp_score_0(v7)
    val v9: Int = (v8 - 11)
    return v9
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
