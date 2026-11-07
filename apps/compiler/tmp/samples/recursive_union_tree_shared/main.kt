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
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: Int = 2
    val v2: UH0 = UH0_Leaf
    val v3: UH0 = UH0_Node(v1, v2, v2)
    var v4: UH0 = UH0_Leaf
    v4 = UH0_Node(v0, v3, v3)
    var v5: Int = 0
    v5 = sp_sum_0(v4)
    var v6: Int = 0
    v6 = (v5 - 5)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
