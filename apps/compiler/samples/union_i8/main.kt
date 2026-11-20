sealed interface US0 { val tag: Int }
object US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Byte) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: Byte = (100).toByte()
    val v1: Boolean = true
    var v4: US0 = US0_Missing
    if (v1) {
        v4 = US0_Held(v0)
    } else {
        v4 = US0_Missing
    }
    when (v4.tag) {
        1 -> {
            var v5: Byte = (v4 as US0_Held).f0
            val v6: Boolean = (v5 == (100).toByte())
            if (v6) {
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
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
