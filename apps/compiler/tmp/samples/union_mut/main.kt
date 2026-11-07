class Mut0(var l0: Int)
sealed interface US0 { val tag: Int }
object US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Mut0) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: Mut0 = Mut0(1)
    val v1: Boolean = true
    var v4: US0 = US0_Missing
    if (v1) {
        v4 = US0_Held(v0)
    } else {
        v4 = US0_Missing
    }
    when (v4.tag) {
        1 -> {
            var v5: Mut0 = (v4 as US0_Held).f0
            v5.l0 = 7
            val v6: Int = v5.l0
            val v7: Boolean = (v6 == 7)
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
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
