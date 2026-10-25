class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
class Heap3(val l0: US0)
class Heap4(val l0: US1)
class Mut5(var l0: Heap4)
sealed interface US0 { val tag: Int }
object US0_None : US0 { override val tag: Int = 0 }
data class US0_Held(val f0: Heap2) : US0 { override val tag: Int = 1 }
sealed interface US1 { val tag: Int }
object US1_Absent : US1 { override val tag: Int = 0 }
data class US1_Box(val f0: Heap3) : US1 { override val tag: Int = 1 }
fun sp_score_0(p0: US1): Int {
    var v0: US1 = p0
    when (v0.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v1: Heap3 = (v0 as US1_Box).f0
            var v2: US0 = US0_None
            v2 = v1.l0
            when (v2.tag) {
                1 -> {
                    var v3: Heap2 = (v2 as US0_Held).f0
                    var v4: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
                    var v5: Int = 0
                    v4 = v3.l0
                    v5 = v3.l1
                    var v6: Heap0 = Heap0(0, "")
                    var v7: Heap0 = Heap0(0, "")
                    v6 = v4.l0
                    v7 = v4.l1
                    var v8: Int = 0
                    var v9: String = ""
                    v8 = v6.l0
                    v9 = v6.l1
                    var v10: Int = 0
                    var v11: String = ""
                    v10 = v7.l0
                    v11 = v7.l1
                    var v12: Boolean = false
                    v12 = (v8 == 7)
                    var v14: Boolean = false
                    if (v12) {
                        var v13: Boolean = false
                        v13 = (v9 == "hi")
                        v14 = v13
                    } else {
                        v14 = false
                    }
                    var v16: Boolean = false
                    if (v14) {
                        val v15: Boolean = (v10 == 4)
                        v16 = v15
                    } else {
                        v16 = false
                    }
                    var v18: Boolean = false
                    if (v16) {
                        var v17: Boolean = false
                        v17 = (v11 == "yo")
                        v18 = v17
                    } else {
                        v18 = false
                    }
                    var v20: Boolean = false
                    if (v18) {
                        var v19: Boolean = false
                        v19 = (v5 == 2)
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
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: String = "no"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    val v3: Int = 2
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
    var v12: US0 = US0_None
    if (v9) {
        v12 = US0_Held(v8)
    } else {
        v12 = US0_None
    }
    var v13: Heap3 = Heap3(US0_None)
    v13 = Heap3(v12)
    var v14: Boolean = false
    v14 = true
    var v17: US1 = US1_Absent
    if (v14) {
        v17 = US1_Box(v13)
    } else {
        v17 = US1_Absent
    }
    var v18: Heap4 = Heap4(US1_Absent)
    v18 = Heap4(v17)
    var v19: Mut5 = Mut5(Heap4(US1_Absent))
    v19 = Mut5(v18)
    var v20: Array<Mut5> = emptyArray<Mut5>()
    v20 = Array(1) { Mut5(Heap4(US1_Absent)) }
    v20[0] = v19
    val v21: Int = 7
    val v22: String = "hi"
    val v23: Heap0 = Heap0(v21, v22)
    val v24: Int = 4
    val v25: String = "yo"
    val v26: Heap0 = Heap0(v24, v25)
    val v27: Heap1 = Heap1(v23, v26)
    val v28: Int = 2
    val v29: Heap2 = Heap2(v27, v28)
    val v30: Boolean = true
    var v33: US0 = US0_None
    if (v30) {
        v33 = US0_Held(v29)
    } else {
        v33 = US0_None
    }
    val v34: Heap3 = Heap3(v33)
    val v35: Boolean = true
    var v38: US1 = US1_Absent
    if (v35) {
        v38 = US1_Box(v34)
    } else {
        v38 = US1_Absent
    }
    val v39: Heap4 = Heap4(v38)
    var v40: Mut5 = Mut5(Heap4(US1_Absent))
    v40 = v20[0]
    v40.l0 = v39
    val v41: Heap4 = v40.l0
    val v42: US1 = v41.l0
    return sp_score_0(v42)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
