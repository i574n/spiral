sealed interface US0 { val tag: Int }
class US0_Empty : US0 { override val tag: Int = 0 }
data class US0_Values(val f0: Array<Int>) : US0 { override val tag: Int = 1 }
fun sp_bump_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            return 0
        }
        1 -> {
            var v1: Array<Int> = (v0 as US0_Values).f0
            var v2: Int = 0
            v2 = v1[0]
            var v3: Int = 0
            v3 = (v2 + 1)
            v1[0] = v3
            return 0
        }
        else -> throw RuntimeException()
    }
}
fun sp_score_1(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            return 0
        }
        1 -> {
            var v1: Array<Int> = (v0 as US0_Values).f0
            var v2: Int = 0
            v2 = v1.size
            var v3: Int = 0
            v3 = v1[0]
            var v4: Int = 0
            v4 = (v2 + v3)
            var v5: Int = 0
            v5 = v1[1]
            var v6: Int = 0
            v6 = (v4 + v5)
            return v6
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 4
    v1[1] = 5
    var v2: US0 = US0_Empty()
    v2 = US0_Values(v1)
    var v3: Int = 0
    v3 = sp_bump_0(v2)
    var v4: US0 = US0_Empty()
    v4 = US0_Values(v1)
    var v5: Int = 0
    v5 = sp_score_1(v4)
    var v6: Int = 0
    v6 = (v5 + v3)
    var v7: Int = 0
    v7 = (v6 - 12)
    return v7
}
fun main() {
    System.exit(spiral_main())
}
