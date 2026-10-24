sealed interface US0 { val tag: Int }
object US0_Idle : US0 { override val tag: Int = 0 }
data class US0_Text(val f0: String) : US0 { override val tag: Int = 1 }
data class US0_Note(val f0: String) : US0 { override val tag: Int = 2 }
fun closure0(): (Int) -> US0 {
    fun body(v0: Int): US0 {
        var v1: Boolean = false
        v1 = (v0 == 1)
        if (v1) {
            val v2: String = "alpha"
            return US0_Text(v2)
        } else {
            val v4: String = "beta"
            return US0_Note(v4)
        }
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> US0): US0 {
    var v0: (Int) -> US0 = p0
    return v0(1)
}
fun sp_method1(p0: (Int) -> US0): US0 {
    var v0: (Int) -> US0 = p0
    return v0(2)
}
fun spiral_main(): Int {
    val v0: (Int) -> US0 = closure0()
    var v1: US0 = US0_Idle
    v1 = sp_method0(v0)
    var v6: Int = 0
    when (v1.tag) {
        0 -> {
            v6 = 3
        }
        2 -> {
            var v3: String = (v1 as US0_Note).f0
            v6 = 6
        }
        1 -> {
            var v2: String = (v1 as US0_Text).f0
            v6 = 5
        }
        else -> throw RuntimeException()
    }
    val v7: US0 = sp_method1(v0)
    var v12: Int = 0
    when (v7.tag) {
        0 -> {
            v12 = 3
        }
        2 -> {
            var v9: String = (v7 as US0_Note).f0
            v12 = 6
        }
        1 -> {
            var v8: String = (v7 as US0_Text).f0
            v12 = 5
        }
        else -> throw RuntimeException()
    }
    val v13: Int = (v6 + v12)
    val v14: Int = (v13 + 31)
    return v14
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
