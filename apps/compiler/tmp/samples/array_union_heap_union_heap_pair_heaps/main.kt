class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
class Heap3(val l0: US0)
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
        v17 = US1_Absent()
    }
    var v18: Array<US1> = emptyArray<US1>()
    v18 = Array(1) { US1_Absent() }
    v18[0] = v17
    var v19: US1 = US1_Absent()
    v19 = v18[0]
    return sp_score_0(v19)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
