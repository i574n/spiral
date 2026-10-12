sealed interface US0 { val tag: Int }
data class US0_Step(val f0: Int, val f1: Int, val f2: Int) : US0 { override val tag: Int = 0 }
fun sp_walk_0(p0: Int): Int {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 > 2)
    var v6: US0 = US0_Step(0, 0, 0)
    if (v1) {
        var v2: Int = 0
        v2 = (v0 + 1)
        var v3: Int = 0
        v3 = (v0 + 2)
        v6 = US0_Step(v0, v2, v3)
    } else {
        v6 = US0_Step(0, 1, 2)
    }
    when (v6.tag) {
        0 -> {
            var v7: Int = (v6 as US0_Step).f0
            var v8: Int = (v6 as US0_Step).f1
            var v9: Int = (v6 as US0_Step).f2
            var v10: Int = 0
            v10 = (v8 * v9)
            var v11: Int = 0
            v11 = (v7 + v10)
            return v11
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 5
    var v1: Int = 0
    v1 = sp_walk_0(v0)
    var v2: Int = 0
    v2 = (v0 - 4)
    var v3: Int = 0
    v3 = sp_walk_0(v2)
    var v4: Int = 0
    v4 = (v1 + v3)
    return v4
}
fun main() {
    System.exit(spiral_main())
}
