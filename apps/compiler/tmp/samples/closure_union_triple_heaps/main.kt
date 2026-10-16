class Heap0(val l0: Int, val l1: String)
sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap0, val f1: Heap0, val f2: Heap0) : US0 { override val tag: Int = 1 }
fun f_c0(v0: Heap0, v1: Heap0, v2: Heap0): (Int) -> US0 {
    fun body(v3: Int): US0 {
        var v4: Boolean = false
        v4 = (v3 == 0)
        if (v4) {
            return US0_None()
        } else {
            return US0_Held(v0, v1, v2)
        }
    }
    return { p0: Int -> body(p0) }
}
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Heap0 = (v0 as US0_Held).f0
            var v2: Heap0 = (v0 as US0_Held).f1
            var v3: Heap0 = (v0 as US0_Held).f2
            var v4: Int = 0
            var v5: String = ""
            v4 = v1.l0
            v5 = v1.l1
            var v6: Int = 0
            var v7: String = ""
            v6 = v2.l0
            v7 = v2.l1
            var v8: Int = 0
            var v9: String = ""
            v8 = v3.l0
            v9 = v3.l1
            var v10: Boolean = false
            v10 = (v4 == 7)
            var v12: Boolean = false
            if (v10) {
                var v11: Boolean = false
                v11 = (v5 == "hi")
                v12 = v11
            } else {
                v12 = false
            }
            var v14: Boolean = false
            if (v12) {
                var v13: Boolean = false
                v13 = (v6 == 4)
                v14 = v13
            } else {
                v14 = false
            }
            var v16: Boolean = false
            if (v14) {
                var v15: Boolean = false
                v15 = (v7 == "yo")
                v16 = v15
            } else {
                v16 = false
            }
            var v18: Boolean = false
            if (v16) {
                var v17: Boolean = false
                v17 = (v8 == 9)
                v18 = v17
            } else {
                v18 = false
            }
            var v20: Boolean = false
            if (v18) {
                var v19: Boolean = false
                v19 = (v9 == "ok")
                v20 = v19
            } else {
                v20 = false
            }
            if (v20) {
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
    var v0: Int = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(0, "")
    v5 = Heap0(v3, v4)
    var v6: Int = 0
    v6 = 9
    var v7: String = ""
    v7 = "ok"
    var v8: Heap0 = Heap0(0, "")
    v8 = Heap0(v6, v7)
    var v9: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v9 = f_c0(v2, v5, v8)
    var v10: US0 = US0_None()
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
