class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
class Heap3(val l0: US0)
class Heap4(val l0: US1)
sealed interface US0 { val tag: Int }
class US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap2) : US0 { override val tag: Int = 1 }
sealed interface US1 { val tag: Int }
class US1_Absent : US1 { override val tag: Int = 0 }
data class US1_Box(val f0: Heap3) : US1 { override val tag: Int = 1 }
data class US1_Mark(val f0: Int) : US1 { override val tag: Int = 2 }
fun f_c0(v0: US1, v1: Int): (Int) -> US1 {
    fun body(v2: Int): US1 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            return US1_Absent()
        } else {
            var v5: Boolean = false
            v5 = (v2 == 1)
            if (v5) {
                return v0
            } else {
                return US1_Mark(v1)
            }
        }
    }
    return { p0: Int -> body(p0) }
}
fun sp_score_0(p0: US1): Int {
    var v0: US1 = p0
    when (v0.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v3: Heap3 = (v0 as US1_Box).f0
            var v4: US0 = US0_None()
            v4 = v3.l0
            when (v4.tag) {
                1 -> {
                    var v5: Heap2 = (v4 as US0_Held).f0
                    var v6: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
                    var v7: Int = 0
                    v6 = v5.l0
                    v7 = v5.l1
                    var v8: Heap0 = Heap0(0, "")
                    var v9: Heap0 = Heap0(0, "")
                    v8 = v6.l0
                    v9 = v6.l1
                    var v10: Int = 0
                    var v11: String = ""
                    v10 = v8.l0
                    v11 = v8.l1
                    var v12: Int = 0
                    var v13: String = ""
                    v12 = v9.l0
                    v13 = v9.l1
                    var v14: Boolean = false
                    v14 = (v10 == 7)
                    var v16: Boolean = false
                    if (v14) {
                        var v15: Boolean = false
                        v15 = (v11 == "hi")
                        v16 = v15
                    } else {
                        v16 = false
                    }
                    var v18: Boolean = false
                    if (v16) {
                        var v17: Boolean = false
                        v17 = (v12 == 4)
                        v18 = v17
                    } else {
                        v18 = false
                    }
                    var v20: Boolean = false
                    if (v18) {
                        var v19: Boolean = false
                        v19 = (v13 == "yo")
                        v20 = v19
                    } else {
                        v20 = false
                    }
                    var v22: Boolean = false
                    if (v20) {
                        var v21: Boolean = false
                        v21 = (v7 == 2)
                        v22 = v21
                    } else {
                        v22 = false
                    }
                    if (v22) {
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
        2 -> {
            var v1: Int = (v0 as US1_Mark).f0
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
    var v6: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v6 = Heap1(v2, v5)
    var v7: Int = 0
    v7 = 2
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
    var v14: Boolean = false
    v14 = true
    var v17: US1 = US1_Absent()
    if (v14) {
        v17 = US1_Box(v13)
    } else {
        v17 = US1_Mark(1)
    }
    var v18: Int = 0
    v18 = 3
    var v19: (Int) -> US1 = { _: Int -> throw RuntimeException() }
    v19 = f_c0(v17, v18)
    var v20: US1 = US1_Absent()
    v20 = v19(1)
    var v21: Heap4 = Heap4(US1_Absent())
    v21 = Heap4(v20)
    var v22: US1 = US1_Absent()
    v22 = v19(2)
    var v23: Heap4 = Heap4(US1_Absent())
    v23 = Heap4(v22)
    var v24: US1 = US1_Absent()
    v24 = v19(0)
    var v25: Heap4 = Heap4(US1_Absent())
    v25 = Heap4(v24)
    var v26: Array<Heap4> = emptyArray<Heap4>()
    v26 = Array(3) { Heap4(US1_Absent()) }
    v26[0] = v21
    v26[1] = v23
    v26[2] = v25
    var v27: Heap4 = Heap4(US1_Absent())
    v27 = v26[0]
    var v28: US1 = US1_Absent()
    v28 = v27.l0
    var v29: Heap4 = Heap4(US1_Absent())
    v29 = v26[1]
    var v30: US1 = US1_Absent()
    v30 = v29.l0
    var v31: Heap4 = Heap4(US1_Absent())
    v31 = v26[2]
    var v32: US1 = US1_Absent()
    v32 = v31.l0
    var v33: Int = 0
    v33 = sp_score_0(v28)
    var v34: Int = 0
    v34 = sp_score_0(v30)
    var v35: Int = 0
    v35 = sp_score_0(v32)
    var v36: Boolean = false
    v36 = (v33 == 0)
    var v38: Boolean = false
    if (v36) {
        var v37: Boolean = false
        v37 = (v34 == 1)
        v38 = v37
    } else {
        v38 = false
    }
    var v40: Boolean = false
    if (v38) {
        var v39: Boolean = false
        v39 = (v35 == 1)
        v40 = v39
    } else {
        v40 = false
    }
    if (v40) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
