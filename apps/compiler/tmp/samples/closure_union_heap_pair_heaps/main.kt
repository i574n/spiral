class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap2) : US0 { override val tag: Int = 1 }
fun f_c0(v0: Heap2): (Int) -> US0 {
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
            var v1: Heap2 = (v0 as US0_Held).f0
            var v2: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
            var v3: Int = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Heap0 = Heap0(0, "")
            var v5: Heap0 = Heap0(0, "")
            v4 = v2.l0
            v5 = v2.l1
            var v6: Int = 0
            var v7: String = ""
            v6 = v4.l0
            v7 = v4.l1
            var v8: Int = 0
            var v9: String = ""
            v8 = v5.l0
            v9 = v5.l1
            var v10: Boolean = false
            v10 = (v6 == 7)
            var v12: Boolean = false
            if (v10) {
                val v11: Boolean = (v7 == "hi")
                v12 = v11
            } else {
                v12 = false
            }
            var v14: Boolean = false
            if (v12) {
                val v13: Boolean = (v8 == 4)
                v14 = v13
            } else {
                v14 = false
            }
            var v16: Boolean = false
            if (v14) {
                val v15: Boolean = (v9 == "yo")
                v16 = v15
            } else {
                v16 = false
            }
            var v18: Boolean = false
            if (v16) {
                val v17: Boolean = (v3 == 2)
                v18 = v17
            } else {
                v18 = false
            }
            if (v18) {
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
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(0, "")
    v5 = Heap0(v3, v4)
    var v6: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v6 = Heap1(v2, v5)
    var v7: Int = 0
    v7 = 2
    var v8: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v8 = Heap2(v6, v7)
    var v9: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v9 = f_c0(v8)
    var v10: US0 = US0_None
    v10 = v9(1)
    return sp_score_0(v10)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
