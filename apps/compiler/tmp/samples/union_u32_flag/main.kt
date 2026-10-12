sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_All(val f0: UInt, val f1: String, val f2: Boolean) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: UInt = (v0 as US0_All).f0
            var v2: String = (v0 as US0_All).f1
            var v3: Boolean = (v0 as US0_All).f2
            var v4: Boolean = false
            v4 = (v1 == 4000000000u)
            var v6: Boolean = false
            if (v4) {
                var v5: Boolean = false
                v5 = (v2 == "hi")
                v6 = v5
            } else {
                v6 = false
            }
            var v7: Boolean = false
            v7 = (v6 && v3)
            if (v7) {
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
    var v3: Boolean = false
    v3 = true
    var v6: US0 = US0_None()
    if (v3) {
        v6 = US0_All(v0, v1, v2)
    } else {
        v6 = US0_None()
    }
    return sp_score_0(v6)
}
fun main() {
    System.exit(spiral_main())
}
