sealed interface US0 { val tag: Int }
class US0_Empty : US0 { override val tag: Int = 0 }
data class US0_Values(val f0: Array<Int>) : US0 { override val tag: Int = 1 }
fun closure0(): (Int) -> US0 {
    fun body(v0: Int): US0 {
        var v1: Boolean = false
        v1 = (v0 == 0)
        if (v1) {
            return US0_Empty()
        } else {
            var v3: Array<Int> = emptyArray<Int>()
            v3 = Array(2) { 0 }
            v3[0] = v0
            var v4: Int = 0
            v4 = (v0 + 1)
            v3[1] = v4
            return US0_Values(v3)
        }
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> US0): US0 {
    var v0: (Int) -> US0 = p0
    return v0(0)
}
fun sp_score_1(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            return 3
        }
        1 -> {
            var v1: Array<Int> = (v0 as US0_Values).f0
            var v2: Int = 0
            v2 = v1.size
            var v3: Int = 0
            v3 = v1[0]
            var v4: Int = 0
            v4 = (v2 + v3)
            var v5: Int = 0
            v5 = v1[1]
            var v6: Int = 0
            v6 = (v4 + v5)
            return v6
        }
        else -> throw RuntimeException()
    }
}
fun sp_method2(p0: (Int) -> US0): US0 {
    var v0: (Int) -> US0 = p0
    return v0(4)
}
fun spiral_main(): Int {
    var v0: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v0 = closure0()
    var v1: US0 = US0_Empty()
    v1 = sp_method0(v0)
    var v2: Int = 0
    v2 = sp_score_1(v1)
    var v3: US0 = US0_Empty()
    v3 = sp_method2(v0)
    var v4: Int = 0
    v4 = sp_score_1(v3)
    var v5: Int = 0
    v5 = (v2 + v4)
    var v6: Int = 0
    v6 = (v5 + 28)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
