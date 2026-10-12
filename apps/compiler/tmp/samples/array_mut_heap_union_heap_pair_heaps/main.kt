class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
class Heap3(val l0: US0)
class Mut4(var l0: Heap3)
sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap2) : US0 { override val tag: Int = 1 }
fun sp_score_0(p0: US0): Int {
    var v0: US0 = p0
    when (v0.tag) {
        1 -> {
            var v1: Heap2 = (v0 as US0_Held).f0
            var v2: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
            var v3: Int = 0
            v2 = v1.l0
            v3 = v1.l1
            var v4: Heap0 = Heap0(0, "")
            var v5: Heap0 = Heap0(0, "")
            v4 = v2.l0
            v5 = v2.l1
            var v6: Int = 0
            var v7: String = ""
            v6 = v4.l0
            v7 = v4.l1
            var v8: Int = 0
            var v9: String = ""
            v8 = v5.l0
            v9 = v5.l1
            var v10: Boolean = false
            v10 = (v6 == 7)
            var v12: Boolean = false
            if (v10) {
                var v11: Boolean = false
                v11 = (v7 == "hi")
                v12 = v11
            } else {
                v12 = false
            }
            var v14: Boolean = false
            if (v12) {
                var v13: Boolean = false
                v13 = (v8 == 4)
                v14 = v13
            } else {
                v14 = false
            }
            var v16: Boolean = false
            if (v14) {
                var v15: Boolean = false
                v15 = (v9 == "yo")
                v16 = v15
            } else {
                v16 = false
            }
            var v18: Boolean = false
            if (v16) {
                var v17: Boolean = false
                v17 = (v3 == 2)
                v18 = v17
            } else {
                v18 = false
            }
            if (v18) {
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
    v0 = 1
    var v1: String = ""
    v1 = "no"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 2
    var v4: String = ""
    v4 = "zz"
    var v5: Heap0 = Heap0(0, "")
    v5 = Heap0(v3, v4)
    var v6: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v6 = Heap1(v2, v5)
    var v7: Int = 0
    v7 = 3
    var v8: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v8 = Heap2(v6, v7)
    var v9: Boolean = false
    v9 = true
    var v12: US0 = US0_None()
    if (v9) {
        v12 = US0_Held(v8)
    } else {
        v12 = US0_None()
    }
    var v13: Heap3 = Heap3(US0_None())
    v13 = Heap3(v12)
    var v14: Mut4 = Mut4(Heap3(US0_None()))
    v14 = Mut4(v13)
    var v15: Array<Mut4> = emptyArray<Mut4>()
    v15 = Array(1) { Mut4(Heap3(US0_None())) }
    v15[0] = v14
    var v16: Int = 0
    v16 = 7
    var v17: String = ""
    v17 = "hi"
    var v18: Heap0 = Heap0(0, "")
    v18 = Heap0(v16, v17)
    var v19: Int = 0
    v19 = 4
    var v20: String = ""
    v20 = "yo"
    var v21: Heap0 = Heap0(0, "")
    v21 = Heap0(v19, v20)
    var v22: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v22 = Heap1(v18, v21)
    var v23: Int = 0
    v23 = 2
    var v24: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v24 = Heap2(v22, v23)
    var v25: Boolean = false
    v25 = true
    var v28: US0 = US0_None()
    if (v25) {
        v28 = US0_Held(v24)
    } else {
        v28 = US0_None()
    }
    var v29: Heap3 = Heap3(US0_None())
    v29 = Heap3(v28)
    var v30: Mut4 = Mut4(Heap3(US0_None()))
    v30 = v15[0]
    v30.l0 = v29
    var v31: Heap3 = Heap3(US0_None())
    v31 = v30.l0
    var v32: US0 = US0_None()
    v32 = v31.l0
    return sp_score_0(v32)
}
fun main() {
    System.exit(spiral_main())
}
