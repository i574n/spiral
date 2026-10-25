class Heap0(val l0: Int, val l1: String)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap0, val f1: Heap0, val f2: Heap0) : US0 { override val tag: Int = 1 }
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
                val v11: Boolean = (v5 == "hi")
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
                val v15: Boolean = (v7 == "yo")
                v16 = v15
            } else {
                v16 = false
            }
            var v18: Boolean = false
            if (v16) {
                val v17: Boolean = (v8 == 9)
                v18 = v17
            } else {
                v18 = false
            }
            var v20: Boolean = false
            if (v18) {
                val v19: Boolean = (v9 == "ok")
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
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 4
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
    var v9: Array<US0> = emptyArray<US0>()
    v9 = Array(1) { US0_None }
    var v10: Boolean = false
    v10 = true
    var v13: US0 = US0_None
    if (v10) {
        v13 = US0_Held(v2, v5, v8)
    } else {
        v13 = US0_None
    }
    v9[0] = v13
    var v14: US0 = US0_None
    v14 = v9[0]
    return sp_score_0(v14)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
