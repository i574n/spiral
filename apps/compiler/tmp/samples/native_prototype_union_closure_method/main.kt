sealed interface US0 { val tag: Int }
class US0_Idle : US0 { override val tag: Int = 0 }
data class US0_Hit(val f0: Int) : US0 { override val tag: Int = 1 }
data class US0_Flag(val f0: Boolean) : US0 { override val tag: Int = 2 }
fun closure0(v0: US0): (Int) -> Int {
    fun body(v1: Int): Int {
        var v7: Int = 0
        when (v0.tag) {
            2 -> {
                var v3: Boolean = (v0 as US0_Flag).f0
                if (v3) {
                    v7 = 11
                } else {
                    v7 = 5
                }
            }
            1 -> {
                var v2: Int = (v0 as US0_Hit).f0
                v7 = v2
            }
            0 -> {
                v7 = 3
            }
            else -> throw RuntimeException()
        }
        var v8: Int = 0
        v8 = (v7 + v1)
        return v8
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> Int): Int {
    var v0: (Int) -> Int = p0
    return v0(31)
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Boolean = false
    v1 = (v0 == 0)
    var v7: US0 = US0_Idle()
    if (v1) {
        v7 = US0_Idle()
    } else {
        var v3: Boolean = false
        v3 = (v0 == 1)
        if (v3) {
            v7 = US0_Hit(7)
        } else {
            v7 = US0_Flag(true)
        }
    }
    var v8: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v8 = closure0(v7)
    return sp_method0(v8)
}
fun main() {
    System.exit(spiral_main())
}
