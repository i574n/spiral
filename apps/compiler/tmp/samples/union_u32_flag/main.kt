sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_All(val f0: UInt, val f1: String, val f2: Boolean) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: UInt = (v0 as US0_All).f0
            var v2: String = (v0 as US0_All).f1
            var v3: Boolean = (v0 as US0_All).f2
            val v4: Boolean = (v1 == 4000000000u)
            var v6: Boolean = false
            if (v4) {
                val v5: Boolean = (v2 == "hi")
                v6 = v5
            } else {
                v6 = false
            }
            val v7: Boolean = (v6 && v3)
            if (v7) {
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
    val v0: UInt = 4000000000u
    val v1: String = "hi"
    val v2: Boolean = true
    val v3: Boolean = true
    var v6: US0 = US0_None
    if (v3) {
        v6 = US0_All(v0, v1, v2)
    } else {
        v6 = US0_None
    }
    return sp_score_0(v6)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
