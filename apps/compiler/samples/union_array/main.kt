sealed interface US0 { val tag: Int }
object US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Array<Int>) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    val v2: Int = 7
    v1[0] = v2
    val v3: Boolean = true
    var v6: US0 = US0_Missing
    if (v3) {
        v6 = US0_Held(v1)
    } else {
        v6 = US0_Missing
    }
    when (v6.tag) {
        1 -> {
            var v7: Array<Int> = (v6 as US0_Held).f0
            val v8: Int = v7[0]
            val v9: Boolean = (v8 == 7)
            if (v9) {
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
