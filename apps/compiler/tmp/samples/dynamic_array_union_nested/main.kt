sealed interface US0 { val tag: Int }
class US0_Empty : US0 { override val tag: Int = 0 }
data class US0_Nested(val f0: Array<Array<Int>>) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        0 -> {
            return 0
        }
        1 -> {
            var v1: Array<Array<Int>> = (v0 as US0_Nested).f0
            var v2: Array<Int> = emptyArray<Int>()
            v2 = v1[0]
            var v3: Array<Int> = emptyArray<Int>()
            v3 = v1[1]
            var v4: Int = 0
            v4 = v1.size
            var v5: Int = 0
            v5 = v2[0]
            var v6: Int = 0
            v6 = (v4 + v5)
            var v7: Int = 0
            v7 = v2[1]
            var v8: Int = 0
            v8 = (v6 + v7)
            var v9: Int = 0
            v9 = v3[0]
            var v10: Int = 0
            v10 = (v8 + v9)
            var v11: Int = 0
            v11 = v3[1]
            var v12: Int = 0
            v12 = (v10 + v11)
            return v12
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Array<Int>> = emptyArray<Array<Int>>()
    v1 = Array(v0) { emptyArray<Int>() }
    var v2: Array<Int> = emptyArray<Int>()
    v2 = Array(v0) { 0 }
    var v3: Array<Int> = emptyArray<Int>()
    v3 = Array(v0) { 0 }
    v2[0] = 3
    v2[1] = 4
    v3[0] = 5
    v3[1] = 6
    v1[0] = v2
    v1[1] = v3
    var v4: US0 = US0_Empty()
    v4 = US0_Nested(v1)
    var v5: Int = 0
    v5 = sp_score_0(v4)
    var v6: Int = 0
    v6 = (v5 - 20)
    return v6
}
fun main() {
    System.exit(spiral_main())
}
