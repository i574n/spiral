sealed interface US0 { val tag: Int }
object US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Array<Double>) : US0 { override val tag: Int = 1 }
fun spiral_main(): Int {
    var v0: Array<Double> = emptyArray<Double>()
    v0 = Array(1) { 0.0 }
    val v1: Double = 1.5
    v0[0] = v1
    val v2: Boolean = true
    var v5: US0 = US0_Missing
    if (v2) {
        v5 = US0_Held(v0)
    } else {
        v5 = US0_Missing
    }
    when (v5.tag) {
        1 -> {
            var v6: Array<Double> = (v5 as US0_Held).f0
            val v7: Double = v6[0]
            val v8: Boolean = (v7 == 1.5)
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
