sealed interface UH0 { val tag: Int }
object UH0_Nil : UH0 { override val tag: Int = 0 }
data class UH0_Cons(val f0: Int, val f1: UH0) : UH0 { override val tag: Int = 1 }
fun sp_sum_0(p0: UH0): Int {
    var v0: UH0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Int = (v0 as UH0_Cons).f0
            var v2: UH0 = (v0 as UH0_Cons).f1
            var v3: Int = 0
            v3 = sp_sum_0(v2)
            var v4: Int = 0
            v4 = (v1 + v3)
            return v4
        }
        0 -> {
            return 0
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: Int = 2
    val v2: Int = 3
    var v3: UH0 = UH0_Nil
    v3 = UH0_Nil
    var v4: UH0 = UH0_Nil
    v4 = UH0_Cons(v2, v3)
    val v5: UH0 = UH0_Cons(v1, v4)
    val v6: UH0 = UH0_Cons(v0, v5)
    val v7: Int = sp_sum_0(v6)
    val v8: Int = (v7 - 6)
    return v8
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
