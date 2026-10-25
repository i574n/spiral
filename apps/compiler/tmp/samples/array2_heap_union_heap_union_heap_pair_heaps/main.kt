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
fun sp_score_0(p0: US1): Int {
    var v0: US1 = p0
    when (v0.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v1: Heap3 = (v0 as US1_Box).f0
            var v2: US0 = US0_None()
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
                        var v15: Boolean = false
                        v15 = (v10 == 4)
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
fun sp_score_b_1(p0: US1): Int {
    var v0: US1 = p0
    when (v0.tag) {
        0 -> {
            return 1
        }
        1 -> {
            var v1: Heap3 = (v0 as US1_Box).f0
            var v2: US0 = US0_None()
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
                    v12 = (v8 == 8)
                    var v14: Boolean = false
                    if (v12) {
                        var v13: Boolean = false
                        v13 = (v9 == "ok")
                        v14 = v13
                    } else {
                        v14 = false
                    }
                    var v16: Boolean = false
                    if (v14) {
                        var v15: Boolean = false
                        v15 = (v10 == 5)
                        v16 = v15
                    } else {
                        v16 = false
                    }
                    var v18: Boolean = false
                    if (v16) {
                        var v17: Boolean = false
                        v17 = (v11 == "no")
                        v18 = v17
                    } else {
                        v18 = false
                    }
                    var v20: Boolean = false
                    if (v18) {
                        var v19: Boolean = false
                        v19 = (v5 == 9)
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
    var v9: US0 = US0_None()
    v9 = US0_Held(v8)
    var v10: Heap3 = Heap3(US0_None())
    v10 = Heap3(v9)
    var v11: US1 = US1_Absent()
    v11 = US1_Box(v10)
    var v12: Heap4 = Heap4(US1_Absent())
    v12 = Heap4(v11)
    var v13: Int = 0
    v13 = 8
    var v14: String = ""
    v14 = "ok"
    var v15: Heap0 = Heap0(0, "")
    v15 = Heap0(v13, v14)
    var v16: Int = 0
    v16 = 5
    var v17: String = ""
    v17 = "no"
    var v18: Heap0 = Heap0(0, "")
    v18 = Heap0(v16, v17)
    var v19: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v19 = Heap1(v15, v18)
    var v20: Int = 0
    v20 = 9
    var v21: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v21 = Heap2(v19, v20)
    var v22: US0 = US0_None()
    v22 = US0_Held(v21)
    var v23: Heap3 = Heap3(US0_None())
    v23 = Heap3(v22)
    var v24: US1 = US1_Absent()
    v24 = US1_Box(v23)
    var v25: Heap4 = Heap4(US1_Absent())
    v25 = Heap4(v24)
    var v26: Array<Heap4> = emptyArray<Heap4>()
    v26 = Array(2) { Heap4(US1_Absent()) }
    v26[0] = v12
    v26[1] = v25
    var v27: Heap4 = Heap4(US1_Absent())
    v27 = v26[0]
    var v28: Heap4 = Heap4(US1_Absent())
    v28 = v26[1]
    var v29: US1 = US1_Absent()
    v29 = v27.l0
    var v30: US1 = US1_Absent()
    v30 = v28.l0
    var v31: Int = 0
    v31 = sp_score_0(v29)
    var v32: Int = 0
    v32 = sp_score_b_1(v30)
    var v33: Boolean = false
    v33 = (v31 == 0)
    var v35: Boolean = false
    if (v33) {
        var v34: Boolean = false
        v34 = (v32 == 0)
        v35 = v34
    } else {
        v35 = false
    }
    if (v35) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
