sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Both(val f0: String, val f1: String) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: String = (v0 as US0_Both).f0
            var v2: String = (v0 as US0_Both).f1
            var v3: Boolean = false
            v3 = (v1 == "hi")
            var v5: Boolean = false
            if (v3) {
                var v4: Boolean = false
                v4 = (v2 == "yo")
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
    var v0: Array<US0> = emptyArray<US0>()
    v0 = Array(1) { US0_None() }
    var v1: String = ""
    v1 = "hi"
    var v2: String = ""
    v2 = "yo"
    var v3: Boolean = false
    v3 = true
    var v6: US0 = US0_None()
    if (v3) {
        v6 = US0_Both(v1, v2)
    } else {
        v6 = US0_None()
    }
    v0[0] = v6
    var v7: US0 = US0_None()
    v7 = v0[0]
    return sp_score_0(v7)
}
fun main() {
    System.exit(spiral_main())
}
