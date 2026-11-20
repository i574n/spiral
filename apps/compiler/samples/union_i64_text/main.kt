sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Both(val f0: Long, val f1: String) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Long = (v0 as US0_Both).f0
            var v2: String = (v0 as US0_Both).f1
            val v3: Boolean = (v1 == 5000000000L)
            var v5: Boolean = false
            if (v3) {
                val v4: Boolean = (v2 == "hi")
                v5 = v4
            } else {
                v5 = false
            }
            if (v5) {
                return 0
            } else {
                return 1
            }
        }
        0 -> {
            return 1
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Long = 5000000000L
    val v1: String = "hi"
    val v2: Boolean = true
    var v5: US0 = US0_None
    if (v2) {
        v5 = US0_Both(v0, v1)
    } else {
        v5 = US0_None
    }
    return sp_score_0(v5)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
