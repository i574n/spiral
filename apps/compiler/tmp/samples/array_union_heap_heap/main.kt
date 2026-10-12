class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap1) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Heap1 = (v0 as US0_Held).f0
            var v2: Heap0 = Heap0(0, "")
            var v3: Int = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Int = 0
            var v5: String = ""
            v4 = v2.l0
            v5 = v2.l1
            var v6: Boolean = false
            v6 = (v4 == 7)
            var v8: Boolean = false
            if (v6) {
                var v7: Boolean = false
                v7 = (v5 == "hi")
                v8 = v7
            } else {
                v8 = false
            }
            var v10: Boolean = false
            if (v8) {
                var v9: Boolean = false
                v9 = (v3 == 1)
                v10 = v9
            } else {
                v10 = false
            }
            if (v10) {
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
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 1
    var v4: Heap1 = Heap1(Heap0(0, ""), 0)
    v4 = Heap1(v2, v3)
    var v5: Array<US0> = emptyArray<US0>()
    v5 = Array(1) { US0_None() }
    var v6: Boolean = false
    v6 = true
    var v9: US0 = US0_None()
    if (v6) {
        v9 = US0_Held(v4)
    } else {
        v9 = US0_None()
    }
    v5[0] = v9
    var v10: US0 = US0_None()
    v10 = v5[0]
    return sp_score_0(v10)
}
fun main() {
    System.exit(spiral_main())
}
