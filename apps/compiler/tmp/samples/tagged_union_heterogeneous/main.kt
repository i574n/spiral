sealed interface US0 { val tag: Int }
data class US0_Hit(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Flag(val f0: Boolean) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v2: Boolean = (v0 as US0_Flag).f0
            if (v2) {
                return 9
            } else {
                return 4
            }
        }
        0 -> {
            var v1: Int = (v0 as US0_Hit).f0
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = false
    var v3: US0 = US0_Hit(0)
    if (v0) {
        v3 = US0_Hit(7)
    } else {
        v3 = US0_Flag(true)
    }
    var v4: Int = 0
    v4 = sp_score_0(v3)
    var v5: Int = 0
    v5 = (v4 - 9)
    return v5
}
fun main() {
    System.exit(spiral_main())
}
