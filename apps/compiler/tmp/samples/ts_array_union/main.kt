sealed interface US0 { val tag: Int }
object US0_Empty : US0 { override val tag: Int = 0 }
data class US0_Values(val f0: Array<Int>) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            return 0
        }
        1 -> {
            var v1: Array<Int> = (v0 as US0_Values).f0
            var v2: Int = 0
            v2 = v1.size
            var v3: Int = 0
            v3 = v1[0]
            var v4: Int = 0
            v4 = (v2 + v3)
            val v5: Int = v1[1]
            val v6: Int = (v4 + v5)
            return v6
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 4
    v1[1] = 5
    var v2: US0 = US0_Empty
    v2 = US0_Values(v1)
    var v3: Int = 0
    v3 = sp_score_0(v2)
    var v4: Int = 0
    v4 = (v3 - 11)
    return v4
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
