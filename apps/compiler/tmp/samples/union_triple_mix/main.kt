sealed interface US0 { val tag: Int }
data class US0_One(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_All(val f0: Int, val f1: String, val f2: Boolean) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v2: Int = (v0 as US0_All).f0
            var v3: String = (v0 as US0_All).f1
            var v4: Boolean = (v0 as US0_All).f2
            var v5: Boolean = false
            v5 = (v2 == 7)
            var v7: Boolean = false
            if (v5) {
                var v6: Boolean = false
                v6 = (v3 == "hi")
                v7 = v6
            } else {
                v7 = false
            }
            var v8: Boolean = false
            v8 = (v7 && v4)
            if (v8) {
                return 0
            } else {
                return 1
            }
        }
        0 -> {
            var v1: Int = (v0 as US0_One).f0
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v1: Int = 0
    v1 = 7
    var v2: String = ""
    v2 = "hi"
    var v3: Boolean = false
    v3 = true
    var v6: US0 = US0_One(0)
    if (v0) {
        v6 = US0_All(v1, v2, v3)
    } else {
        v6 = US0_One(1)
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
