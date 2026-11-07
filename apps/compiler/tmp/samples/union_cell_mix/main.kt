class Heap0(val l0: Int)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap0, val f1: Int) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Heap0 = (v0 as US0_Held).f0
            var v2: Int = (v0 as US0_Held).f1
            var v3: Int = 0
            v3 = v1.l0
            val v4: Int = (v3 + v2)
            val v5: Boolean = (v4 == 7)
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
    val v0: Int = 3
    val v1: Int = 4
    val v2: Heap0 = Heap0(v0)
    var v3: Boolean = false
    v3 = true
    var v6: US0 = US0_None
    if (v3) {
        v6 = US0_Held(v2, v1)
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
