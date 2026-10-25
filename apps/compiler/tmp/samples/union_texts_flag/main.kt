sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Array<String>, val f1: Boolean) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Array<String> = (v0 as US0_Held).f0
            var v2: Boolean = (v0 as US0_Held).f1
            var v3: String = ""
            v3 = v1[0]
            var v4: Boolean = false
            v4 = (v3 == "hi")
            var v5: Boolean = false
            v5 = (v4 && v2)
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
    var v0: Array<String> = emptyArray<String>()
    v0 = Array(1) { "" }
    var v1: String = ""
    v1 = "hi"
    v0[0] = v1
    var v2: Boolean = false
    v2 = true
    var v5: US0 = US0_None()
    if (v2) {
        v5 = US0_Held(v0, v2)
    } else {
        v5 = US0_None()
    }
    return sp_score_0(v5)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
