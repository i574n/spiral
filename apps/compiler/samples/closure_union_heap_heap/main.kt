class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap1) : US0 { override val tag: Int = 1 }
fun f_c0(v0: Heap1): (Int) -> US0 {
    fun body(v1: Int): US0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return US0_None
        } else {
            return US0_Held(v0)
        }
    }
    return { p0: Int -> body(p0) }
}
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Heap1 = (v0 as US0_Held).f0
            var v2: Heap0 = Heap0(0, "")
            var v3: Int = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Int = 0
            var v5: String = ""
            v4 = v2.l0
            v5 = v2.l1
            var v6: Boolean = false
            v6 = (v4 == 7)
            var v8: Boolean = false
            if (v6) {
                val v7: Boolean = (v5 == "hi")
                v8 = v7
            } else {
                v8 = false
            }
            var v10: Boolean = false
            if (v8) {
                val v9: Boolean = (v3 == 1)
                v10 = v9
            } else {
                v10 = false
            }
            if (v10) {
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
    val v0: Int = 7
    val v1: String = "hi"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 1
    var v4: Heap1 = Heap1(Heap0(0, ""), 0)
    v4 = Heap1(v2, v3)
    var v5: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v5 = f_c0(v4)
    var v6: US0 = US0_None
    v6 = v5(1)
    return sp_score_0(v6)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
