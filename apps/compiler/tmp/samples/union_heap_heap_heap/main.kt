class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
class Heap2(val l0: Heap1, val l1: Int)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap2) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Heap2 = (v0 as US0_Held).f0
            var v2: Heap1 = Heap1(Heap0(0, ""), 0)
            var v3: Int = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Heap0 = Heap0(0, "")
            var v5: Int = 0
            v4 = v2.l0
            v5 = v2.l1
            var v6: Int = 0
            var v7: String = ""
            v6 = v4.l0
            v7 = v4.l1
            val v8: Boolean = (v6 == 7)
            var v10: Boolean = false
            if (v8) {
                val v9: Boolean = (v7 == "hi")
                v10 = v9
            } else {
                v10 = false
            }
            var v12: Boolean = false
            if (v10) {
                val v11: Boolean = (v5 == 1)
                v12 = v11
            } else {
                v12 = false
            }
            var v14: Boolean = false
            if (v12) {
                val v13: Boolean = (v3 == 2)
                v14 = v13
            } else {
                v14 = false
            }
            if (v14) {
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
    var v5: Int = 0
    v5 = 2
    var v6: Heap2 = Heap2(Heap1(Heap0(0, ""), 0), 0)
    v6 = Heap2(v4, v5)
    var v7: Boolean = false
    v7 = true
    var v10: US0 = US0_None
    if (v7) {
        v10 = US0_Held(v6)
    } else {
        v10 = US0_None
    }
    return sp_score_0(v10)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
