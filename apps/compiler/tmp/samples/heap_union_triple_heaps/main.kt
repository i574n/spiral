class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: US0)
sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap0, val f1: Heap0, val f2: Heap0) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Heap0 = (v0 as US0_Held).f0
            var v2: Heap0 = (v0 as US0_Held).f1
            var v3: Heap0 = (v0 as US0_Held).f2
            var v4: Int = 0
            var v5: String = ""
            v4 = v1.l0
            v5 = v1.l1
            var v6: Int = 0
            var v7: String = ""
            v6 = v2.l0
            v7 = v2.l1
            var v8: Int = 0
            var v9: String = ""
            v8 = v3.l0
            v9 = v3.l1
            var v10: Boolean = false
            v10 = (v4 == 7)
            var v12: Boolean = false
            if (v10) {
                var v11: Boolean = false
                v11 = (v5 == "hi")
                v12 = v11
            } else {
                v12 = false
            }
            var v14: Boolean = false
            if (v12) {
                var v13: Boolean = false
                v13 = (v6 == 4)
                v14 = v13
            } else {
                v14 = false
            }
            var v16: Boolean = false
            if (v14) {
                var v15: Boolean = false
                v15 = (v7 == "yo")
                v16 = v15
            } else {
                v16 = false
            }
            var v18: Boolean = false
            if (v16) {
                var v17: Boolean = false
                v17 = (v8 == 9)
                v18 = v17
            } else {
                v18 = false
            }
            var v20: Boolean = false
            if (v18) {
                var v19: Boolean = false
                v19 = (v9 == "ok")
                v20 = v19
            } else {
                v20 = false
            }
            if (v20) {
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
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(0, "")
    v5 = Heap0(v3, v4)
    var v6: Int = 0
    v6 = 9
    var v7: String = ""
    v7 = "ok"
    var v8: Heap0 = Heap0(0, "")
    v8 = Heap0(v6, v7)
    var v9: Boolean = false
    v9 = true
    var v12: US0 = US0_None()
    if (v9) {
        v12 = US0_Held(v2, v5, v8)
    } else {
        v12 = US0_None()
    }
    var v13: Heap1 = Heap1(US0_None())
    v13 = Heap1(v12)
    var v14: US0 = US0_None()
    v14 = v13.l0
    return sp_score_0(v14)
}
fun main() {
    System.exit(spiral_main())
}
