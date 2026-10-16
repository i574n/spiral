sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Call(val f0: (Int) -> Int, val f1: Int) : US0 { override val tag: Int = 1 }
fun add_c0(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = (v1 + v0)
        return v2
    }
    return { p0: Int -> body(p0) }
}
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: (Int) -> Int = (v0 as US0_Call).f0
            var v2: Int = (v0 as US0_Call).f1
            var v3: Int = 0
            v3 = v1(0)
            var v4: Int = 0
            v4 = (v3 + v2)
            var v5: Boolean = false
            v5 = (v4 == 7)
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
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 4
    var v2: Boolean = false
    v2 = true
    var v6: US0 = US0_None()
    if (v2) {
        var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
        v3 = add_c0(v0)
        v6 = US0_Call(v3, v1)
    } else {
        v6 = US0_None()
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
