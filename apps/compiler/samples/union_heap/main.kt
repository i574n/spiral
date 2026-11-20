class Heap0(val l0: Int)
sealed interface US0 { val tag: Int }
object US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Box(val f0: Heap0) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: Heap0 = Heap0(v0)
    val v2: Boolean = true
    var v5: US0 = US0_Missing
    if (v2) {
        v5 = US0_Box(v1)
    } else {
        v5 = US0_Missing
    }
    when (v5.tag) {
        1 -> {
            var v6: Heap0 = (v5 as US0_Box).f0
            val v7: Int = v6.l0
            val v8: Boolean = (v7 == 7)
            if (v8) {
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
