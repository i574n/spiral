sealed interface US0 { val tag: Int }
object US0_Missing : US0 { override val tag: Int = 0 }
data class US0_Call(val f0: (Int) -> Int) : US0 { override val tag: Int = 1 }
fun f_c0(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = (v1 + v0)
        return v2
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: (Int) -> Int = f_c0(v0)
    var v2: Boolean = false
    v2 = true
    var v5: US0 = US0_Missing
    if (v2) {
        v5 = US0_Call(v1)
    } else {
        v5 = US0_Missing
    }
    when (v5.tag) {
        1 -> {
            var v6: (Int) -> Int = (v5 as US0_Call).f0
            val v7: Int = v6(4)
            val v8: Boolean = (v7 == 7)
            if (v8) {
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
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
