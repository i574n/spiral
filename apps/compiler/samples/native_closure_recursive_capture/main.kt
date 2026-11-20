sealed interface UH0 { val tag: Int }
object UH0_Leaf : UH0 { override val tag: Int = 0 }
data class UH0_Node(val f0: Int, val f1: UH0, val f2: UH0) : UH0 { override val tag: Int = 1 }
fun sp_sum_0(p0: UH0): Int {
    var v0: UH0 = p0
    when (v0.tag) {
        0 -> {
            return 0
        }
        1 -> {
            var v1: Int = (v0 as UH0_Node).f0
            var v2: UH0 = (v0 as UH0_Node).f1
            var v3: UH0 = (v0 as UH0_Node).f2
            var v4: Int = 0
            v4 = sp_sum_0(v2)
            var v5: Int = 0
            v5 = sp_sum_0(v3)
            var v6: Int = 0
            v6 = (v4 + v5)
            val v7: Int = (v1 + v6)
            return v7
        }
        else -> throw RuntimeException()
    }
}
fun f_c0(v0: UH0): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = sp_sum_0(v0)
        var v3: Int = 0
        v3 = (v2 + v1)
        return v3
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: UH0 = UH0_Leaf
    val v1: Int = 2
    var v2: UH0 = UH0_Leaf
    v2 = UH0_Node(v1, v0, v0)
    var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v3 = f_c0(v2)
    var v4: Int = 0
    v4 = v3(19)
    var v5: Int = 0
    v5 = v3(19)
    var v6: Int = 0
    v6 = (v4 + v5)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
