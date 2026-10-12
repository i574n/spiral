sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Array<Int>, val f1: Int) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Array<Int> = (v0 as US0_Held).f0
            var v2: Int = (v0 as US0_Held).f1
            var v3: Int = 0
            v3 = v1[0]
            var v4: Int = 0
            v4 = (v3 + v2)
            var v5: Boolean = false
            v5 = (v4 == 7)
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
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 4
    var v2: Array<Int> = emptyArray<Int>()
    v2 = Array(1) { 0 }
    v2[0] = v0
    var v3: Boolean = false
    v3 = true
    var v6: US0 = US0_None()
    if (v3) {
        v6 = US0_Held(v2, v1)
    } else {
        v6 = US0_None()
    }
    return sp_score_0(v6)
}
fun main() {
    System.exit(spiral_main())
}
