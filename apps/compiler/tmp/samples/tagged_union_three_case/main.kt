sealed interface US0 { val tag: Int }
class US0_Idle : US0 { override val tag: Int = 0 }
data class US0_Hit(val f0: Int) : US0 { override val tag: Int = 1 }
data class US0_Flag(val f0: Boolean) : US0 { override val tag: Int = 2 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        2 -> {
            var v2: Boolean = (v0 as US0_Flag).f0
            if (v2) {
                return 11
            } else {
                return 5
            }
        }
        1 -> {
            var v1: Int = (v0 as US0_Hit).f0
            return v1
        }
        0 -> {
            return 3
        }
        else -> throw RuntimeException()
    }
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
    var v8: Int = 0
    v8 = sp_score_0(v7)
    var v9: Int = 0
    v9 = (v8 - 11)
    return v9
}
fun main() {
    System.exit(spiral_main())
}
