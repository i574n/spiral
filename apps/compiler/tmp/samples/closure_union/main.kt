sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Some(val f0: Int) : US0 { override val tag: Int = 1 }
fun f_c0(v0: Int): (Int) -> US0 {
    fun body(v1: Int): US0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return US0_None()
        } else {
            return US0_Some(v0)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: US0 = US0_None()
    v2 = v1(1)
    when (v2.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v3: Int = (v2 as US0_Some).f0
            var v4: Boolean = false
            v4 = (v3 == 7)
            if (v4) {
                return 0
            } else {
                return 1
            }
        }
        else -> throw RuntimeException()
    }
}
fun main() {
    System.exit(spiral_main())
}
