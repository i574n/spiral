class Heap0(val l0: US0)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: Boolean = true
    var v4: US0 = US0_None
    if (v1) {
        v4 = US0_Some(v0)
    } else {
        v4 = US0_None
    }
    val v5: Heap0 = Heap0(v4)
    val v6: US0 = v5.l0
    when (v6.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v7: Int = (v6 as US0_Some).f0
            val v8: Boolean = (v7 == 7)
            if (v8) {
                return 0
            } else {
                return 1
            }
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
