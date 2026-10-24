sealed interface US0 { val tag: Int }
object US0_Cold : US0 { override val tag: Int = 0 }
object US0_Warm : US0 { override val tag: Int = 1 }
object US0_Hot : US0 { override val tag: Int = 2 }
object US0_Done : US0 { override val tag: Int = 3 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            return 1
        }
        3 -> {
            return 4
        }
        2 -> {
            return 3
        }
        1 -> {
            return 2
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Boolean = (v0 == 0)
    var v10: US0 = US0_Cold
    if (v1) {
        v10 = US0_Cold
    } else {
        val v3: Boolean = (v0 == 1)
        if (v3) {
            v10 = US0_Warm
        } else {
            val v5: Boolean = (v0 == 2)
            if (v5) {
                v10 = US0_Hot
            } else {
                v10 = US0_Done
            }
        }
    }
    val v11: Int = sp_score_0(v10)
    val v12: Int = (v11 - 4)
    return v12
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
