sealed interface US0 { val tag: Int }
class US0_Missing : US0 { override val tag: Int = 0 }
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
    var v0: Int = 0
    v0 = 3
    var v1: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: Boolean = false
    v2 = true
    var v5: US0 = US0_Missing()
    if (v2) {
        v5 = US0_Call(v1)
    } else {
        v5 = US0_Missing()
    }
    when (v5.tag) {
        1 -> {
            var v6: (Int) -> Int = (v5 as US0_Call).f0
            var v7: Int = 0
            v7 = v6(4)
            var v8: Boolean = false
            v8 = (v7 == 7)
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
    System.exit(spiral_main())
}
