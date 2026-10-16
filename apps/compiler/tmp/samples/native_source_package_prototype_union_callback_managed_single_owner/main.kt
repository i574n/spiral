sealed interface US0 { val tag: Int }
class US0_Idle : US0 { override val tag: Int = 0 }
data class US0_Text(val f0: String) : US0 { override val tag: Int = 1 }
fun closure0(): (Int) -> US0 {
    fun body(v0: Int): US0 {
        var v1: String = ""
        v1 = "managed"
        return US0_Text(v1)
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> US0): US0 {
    var v0: (Int) -> US0 = p0
    return v0(2)
}
fun spiral_main(): Int {
    var v0: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v0 = closure0()
    var v1: US0 = US0_Idle()
    v1 = sp_method0(v0)
    var v4: Int = 0
    when (v1.tag) {
        0 -> {
            v4 = 3
        }
        1 -> {
            var v2: String = (v1 as US0_Text).f0
            v4 = 11
        }
        else -> throw RuntimeException()
    }
    var v5: Int = 0
    v5 = (v4 + 31)
    return v5
}
fun main() {
    System.exit(spiral_main())
}
