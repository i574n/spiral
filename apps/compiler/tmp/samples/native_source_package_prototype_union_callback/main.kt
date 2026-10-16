sealed interface US0 { val tag: Int }
class US0_Idle : US0 { override val tag: Int = 0 }
data class US0_Hit(val f0: Int) : US0 { override val tag: Int = 1 }
data class US0_Flag(val f0: Boolean) : US0 { override val tag: Int = 2 }
fun closure0(v0: Int): (Int) -> US0 {
    fun body(v1: Int): US0 {
        var v2: Boolean = false
        v2 = (v1 == v0)
        return US0_Flag(v2)
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> US0, p1: Int): US0 {
    var v0: (Int) -> US0 = p0
    var v1: Int = p1
    return v0(v1)
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v1 = closure0(v0)
    var v2: US0 = US0_Idle()
    v2 = sp_method0(v1, v0)
    var v8: Int = 0
    when (v2.tag) {
        2 -> {
            var v4: Boolean = (v2 as US0_Flag).f0
            if (v4) {
                v8 = 11
            } else {
                v8 = 5
            }
        }
        1 -> {
            var v3: Int = (v2 as US0_Hit).f0
            v8 = v3
        }
        0 -> {
            v8 = 3
        }
        else -> throw RuntimeException()
    }
    var v9: Int = 0
    v9 = (v8 + 31)
    return v9
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
