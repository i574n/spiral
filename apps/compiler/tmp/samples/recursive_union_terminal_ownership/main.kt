sealed interface UH0 { val tag: Int }
class UH0_Leaf : UH0 { override val tag: Int = 0 }
data class UH0_Node(val f0: Int, val f1: UH0, val f2: UH0) : UH0 { override val tag: Int = 1 }
fun sp_sum_1(p0: UH0): Int {
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
            v4 = sp_sum_1(v2)
            var v5: Int = 0
            v5 = sp_sum_1(v3)
            var v6: Int = 0
            v6 = (v4 + v5)
            var v7: Int = 0
            v7 = (v1 + v6)
            return v7
        }
        else -> throw RuntimeException()
    }
}
fun sp_consume_pair_0(p0: UH0, p1: UH0): Int {
    var v0: UH0 = p0
    var v1: UH0 = p1
    var v2: Int = 0
    v2 = sp_sum_1(v0)
    var v3: Int = 0
    v3 = sp_sum_1(v1)
    var v4: Int = 0
    v4 = (v2 + v3)
    return v4
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Int = 0
    v1 = 2
    var v2: UH0 = UH0_Leaf()
    v2 = UH0_Leaf()
    var v3: UH0 = UH0_Leaf()
    v3 = UH0_Node(v1, v2, v2)
    var v4: UH0 = UH0_Leaf()
    v4 = UH0_Node(v0, v3, v3)
    var v5: Int = 0
    v5 = 1
    var v6: Int = 0
    v6 = 2
    var v7: UH0 = UH0_Leaf()
    v7 = UH0_Leaf()
    var v8: UH0 = UH0_Leaf()
    v8 = UH0_Node(v6, v7, v7)
    var v9: UH0 = UH0_Leaf()
    v9 = UH0_Node(v5, v8, v8)
    var v10: Int = 0
    v10 = sp_consume_pair_0(v4, v9)
    var v11: Int = 0
    v11 = (v10 - 10)
    return v11
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
