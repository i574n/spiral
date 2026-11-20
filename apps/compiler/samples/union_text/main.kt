sealed interface US0 { val tag: Int }
data class US0_Text(val f0: String) : US0 { override val tag: Int = 0 }
data class US0_Code(val f0: Int) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v4: Int = (v0 as US0_Code).f0
            return v4
        }
        0 -> {
            var v1: String = (v0 as US0_Text).f0
            val v2: Boolean = (v1 == "hi")
            if (v2) {
                return 2
            } else {
                return 3
            }
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Boolean = true
    val v1: String = "hi"
    var v4: US0 = US0_Text("")
    if (v0) {
        v4 = US0_Text(v1)
    } else {
        v4 = US0_Code(1)
    }
    var v7: US0 = US0_Text("")
    if (v0) {
        v7 = US0_Code(5)
    } else {
        v7 = US0_Text(v1)
    }
    val v8: Int = sp_score_0(v4)
    val v9: Boolean = (v8 == 2)
    var v12: Boolean = false
    if (v9) {
        val v10: Int = sp_score_0(v7)
        val v11: Boolean = (v10 == 5)
        v12 = v11
    } else {
        v12 = false
    }
    if (v12) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
