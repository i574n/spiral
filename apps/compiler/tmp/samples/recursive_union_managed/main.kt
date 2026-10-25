sealed interface UH0 { val tag: Int }
object UH0_Nil : UH0 { override val tag: Int = 0 }
data class UH0_Cons(val f0: Array<Int>, val f1: UH0) : UH0 { override val tag: Int = 1 }
fun sp_sum_0(p0: UH0): Int {
    var v0: UH0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Array<Int> = (v0 as UH0_Cons).f0
            var v2: UH0 = (v0 as UH0_Cons).f1
            var v3: Int = 0
            v3 = v1.size
            var v4: Int = 0
            v4 = sp_sum_0(v2)
            var v5: Int = 0
            v5 = (v3 + v4)
            return v5
        }
        0 -> {
            return 0
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Int = 2
    val v1: Array<Int> = Array(v0) { 0 }
    val v2: UH0 = UH0_Nil
    var v3: UH0 = UH0_Nil
    v3 = UH0_Cons(v1, v2)
    var v4: UH0 = UH0_Nil
    v4 = UH0_Cons(v1, v3)
    var v5: Int = 0
    v5 = sp_sum_0(v4)
    val v6: Int = (v5 - 4)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
