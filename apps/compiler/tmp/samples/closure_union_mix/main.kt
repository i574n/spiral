sealed interface US0 { val tag: Int }
data class US0_One(val f0: Int) : US0 { override val tag: Int = 0 }
data class US0_Both(val f0: Int, val f1: String) : US0 { override val tag: Int = 1 }
fun f_c0(v0: Int, v1: String): (Int) -> US0 {
    fun body(v2: Int): US0 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            return US0_One(0)
        } else {
            return US0_Both(v0, v1)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: String = ""
    v1 = "hi"
    var v2: (Int) -> US0 = { _: Int -> throw RuntimeException() }
    v2 = f_c0(v0, v1)
    var v3: US0 = US0_One(0)
    v3 = v2(1)
    when (v3.tag) {
        1 -> {
            var v5: Int = (v3 as US0_Both).f0
            var v6: String = (v3 as US0_Both).f1
            var v7: Boolean = false
            v7 = (v5 == 3)
            var v9: Boolean = false
            if (v7) {
                var v8: Boolean = false
                v8 = (v6 == "hi")
                v9 = v8
            } else {
                v9 = false
            }
            if (v9) {
                return 0
            } else {
                return 1
            }
        }
        0 -> {
            var v4: Int = (v3 as US0_One).f0
            return 1
        }
        else -> throw RuntimeException()
    }
}
fun main() {
    System.exit(spiral_main())
}
