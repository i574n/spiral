sealed interface US0 { val tag: Int }
data class US0_One(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Both(val f0: Int, val f1: String) : US0 { override val tag: Int = 1 }
fun sp_method0(p0: Int, p1: String): US0 {
    var v0: Int = p0
    var v1: String = p1
    var v2: Boolean = false
    v2 = (v0 == 0)
    if (v2) {
        return US0_One(0)
    } else {
        return US0_Both(v0, v1)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: String = ""
    v1 = "hi"
    var v2: US0 = US0_One(0)
    v2 = sp_method0(v0, v1)
    when (v2.tag) {
        1 -> {
            var v4: Int = (v2 as US0_Both).f0
            var v5: String = (v2 as US0_Both).f1
            var v6: Boolean = false
            v6 = (v4 == 3)
            var v8: Boolean = false
            if (v6) {
                var v7: Boolean = false
                v7 = (v5 == "hi")
                v8 = v7
            } else {
                v8 = false
            }
            if (v8) {
                return 0
            } else {
                return 1
            }
        }
        0 -> {
            var v3: Int = (v2 as US0_One).f0
            return 1
        }
        else -> throw RuntimeException()
    }
}
fun main() {
    System.exit(spiral_main())
}
