sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Both(val f0: UInt, val f1: String) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: UInt = (v0 as US0_Both).f0
            var v2: String = (v0 as US0_Both).f1
            var v3: Boolean = false
            v3 = (v1 == 4000000000u)
            var v5: Boolean = false
            if (v3) {
                var v4: Boolean = false
                v4 = (v2 == "hi")
                v5 = v4
            } else {
                v5 = false
            }
            if (v5) {
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
fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 4000000000u
    var v1: String = ""
    v1 = "hi"
    var v2: Boolean = false
    v2 = true
    var v5: US0 = US0_None()
    if (v2) {
        v5 = US0_Both(v0, v1)
    } else {
        v5 = US0_None()
    }
    return sp_score_0(v5)
}
fun main() {
    System.exit(spiral_main())
}
