sealed interface UH0 { val tag: Int }
data class UH0_Cons(val f0: ULong, val f1: () -> UH0) : UH0 { override val tag: Int = 0 }
class UH0_Nil : UH0 { override val tag: Int = 1 }
fun closure0(v0: ULong): () -> UH0 {
    fun body(): UH0 {
        var v1: ULong = 0uL
        v1 = (v0 - 1uL)
        return sp_build_0(v1)
    }
    return { body() }
}
fun sp_build_0(p0: ULong): UH0 {
    var v0: ULong = p0
    var v1: Boolean = false
    v1 = (v0 == 0uL)
    if (v1) {
        return UH0_Nil()
    } else {
        var v3: () -> UH0 = { throw RuntimeException() }
        v3 = closure0(v0)
        return UH0_Cons(v0, v3)
    }
}
fun sp_sum_1(p0: UH0, p1: ULong): ULong {
    var v0: UH0 = p0
    var v1: ULong = p1
    when (v0.tag) {
        0 -> {
            var v2: ULong = (v0 as UH0_Cons).f0
            var v3: () -> UH0 = (v0 as UH0_Cons).f1
            var v4: UH0 = UH0_Cons(0uL, { throw RuntimeException() })
            v4 = v3()
            var v5: ULong = 0uL
            v5 = (v1 + v2)
            return sp_sum_1(v4, v5)
        }
        1 -> {
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: ULong = 0uL
    v0 = 10uL
    var v1: UH0 = UH0_Cons(0uL, { throw RuntimeException() })
    v1 = sp_build_0(v0)
    var v2: ULong = 0uL
    v2 = 0uL
    var v3: ULong = 0uL
    v3 = sp_sum_1(v1, v2)
    var v4: Int = 0
    v4 = 5
    var v5: Int = 0
    v5 = (v3).toInt()
    var v6: Int = 0
    v6 = (v4 * 2)
    var v7: Int = 0
    v7 = (v4 + v6)
    var v8: Int = 0
    v8 = (v5 + v7)
    return v8
}
fun main() {
    System.exit(spiral_main())
}
