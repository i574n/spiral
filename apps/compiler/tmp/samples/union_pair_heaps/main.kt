class Heap0(val l0: Int, val l1: String)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap0, val f1: Heap0) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Heap0 = (v0 as US0_Held).f0
            var v2: Heap0 = (v0 as US0_Held).f1
            var v3: Int = 0
            var v4: String = ""
            v3 = v1.l0
            v4 = v1.l1
            var v5: Int = 0
            var v6: String = ""
            v5 = v2.l0
            v6 = v2.l1
            val v7: Boolean = (v3 == 7)
            var v9: Boolean = false
            if (v7) {
                val v8: Boolean = (v4 == "hi")
                v9 = v8
            } else {
                v9 = false
            }
            var v11: Boolean = false
            if (v9) {
                val v10: Boolean = (v5 == 4)
                v11 = v10
            } else {
                v11 = false
            }
            var v13: Boolean = false
            if (v11) {
                val v12: Boolean = (v6 == "yo")
                v13 = v12
            } else {
                v13 = false
            }
            if (v13) {
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
    var v3: Int = 0
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(0, "")
    v5 = Heap0(v3, v4)
    var v6: Boolean = false
    v6 = true
    var v9: US0 = US0_None
    if (v6) {
        v9 = US0_Held(v2, v5)
    } else {
        v9 = US0_None
    }
    return sp_score_0(v9)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
