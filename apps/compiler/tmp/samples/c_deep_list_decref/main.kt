sealed interface UH0 { val tag: Int }
data class UH0_Link(val f0: Int, val f1: UH0) : UH0 { override val tag: Int = 0 }
object UH0_End : UH0 { override val tag: Int = 1 }
object UH0_Zero : UH0 { override val tag: Int = -1 }
fun sp_build_0(p0: Int, p1: UH0): UH0 {
    var v0: Int = p0
    var v1: UH0 = p1
    while (true) {
        var v2: Boolean = false
        v2 = (v0 == 0)
        if (v2) {
            return v1
        } else {
            var v3: Int = 0
            v3 = (v0 - 1)
            var v4: UH0 = UH0_Link(0, UH0_Zero)
            v4 = UH0_Link(v0, v1)
            v0 = v3
            v1 = v4
            continue
        }
    }
    return UH0_Link(0, UH0_Zero)
}
fun sp_sum_1(p0: UH0, p1: Int): Int {
    var v0: UH0 = p0
    var v1: Int = p1
    when (v0.tag) {
        1 -> {
            return v1
        }
        0 -> {
            var v2: Int = (v0 as UH0_Link).f0
            var v3: UH0 = (v0 as UH0_Link).f1
            var v4: Int = 0
            v4 = (v1 * 31)
            var v5: Int = 0
            v5 = (v4 + v2)
            val v6: Int = (v5 % 9973)
            return sp_sum_1(v3, v6)
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1000000
    var v1: UH0 = UH0_Link(0, UH0_Zero)
    v1 = UH0_End
    var v2: UH0 = UH0_Link(0, UH0_Zero)
    v2 = sp_build_0(v0, v1)
    var v3: Int = 0
    v3 = 0
    var v4: Int = 0
    v4 = sp_sum_1(v2, v3)
    var v5: Int = 0
    v5 = (v4 % 256)
    return v5
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
