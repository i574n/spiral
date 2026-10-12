sealed interface US0 { val tag: Int }
data class US0_One(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Both(val f0: Int, val f1: String) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v2: Int = (v0 as US0_Both).f0
            var v3: String = (v0 as US0_Both).f1
            var v4: Boolean = false
            v4 = (v2 == 3)
            var v6: Boolean = false
            if (v4) {
                var v5: Boolean = false
                v5 = (v3 == "hi")
                v6 = v5
            } else {
                v6 = false
            }
            if (v6) {
                return 0
            } else {
                return 1
            }
        }
        0 -> {
            var v1: Int = (v0 as US0_One).f0
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v1: Int = 0
    v1 = 3
    var v2: String = ""
    v2 = "hi"
    var v5: US0 = US0_One(0)
    if (v0) {
        v5 = US0_Both(v1, v2)
    } else {
        v5 = US0_One(1)
    }
    return sp_score_0(v5)
}
fun main() {
    System.exit(spiral_main())
}
