class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
class Mut3(var l0: Heap2)
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
    var v9: Mut3 = Mut3(Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0))
    v9 = Mut3(v8)
    var v10: Array<Mut3> = emptyArray<Mut3>()
    v10 = Array(1) { Mut3(Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)) }
    v10[0] = v9
    var v11: Int = 0
    v11 = 7
    var v12: String = ""
    v12 = "hi"
    var v13: Heap0 = Heap0(0, "")
    v13 = Heap0(v11, v12)
    var v14: Int = 0
    v14 = 4
    var v15: String = ""
    v15 = "yo"
    var v16: Heap0 = Heap0(0, "")
    v16 = Heap0(v14, v15)
    var v17: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v17 = Heap1(v13, v16)
    var v18: Int = 0
    v18 = 2
    var v19: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v19 = Heap2(v17, v18)
    var v20: Mut3 = Mut3(Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0))
    v20 = v10[0]
    v20.l0 = v19
    var v21: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v21 = v20.l0
    var v22: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    var v23: Int = 0
    v22 = v21.l0
    v23 = v21.l1
    var v24: Heap0 = Heap0(0, "")
    var v25: Heap0 = Heap0(0, "")
    v24 = v22.l0
    v25 = v22.l1
    var v26: Int = 0
    var v27: String = ""
    v26 = v24.l0
    v27 = v24.l1
    var v28: Int = 0
    var v29: String = ""
    v28 = v25.l0
    v29 = v25.l1
    var v30: Boolean = false
    v30 = (v26 == 7)
    var v32: Boolean = false
    if (v30) {
        var v31: Boolean = false
        v31 = (v27 == "hi")
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Boolean = false
    if (v32) {
        var v33: Boolean = false
        v33 = (v28 == 4)
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Boolean = false
    if (v34) {
        var v35: Boolean = false
        v35 = (v29 == "yo")
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Boolean = false
    if (v36) {
        var v37: Boolean = false
        v37 = (v23 == 2)
        v38 = v37
    } else {
        v38 = false
    }
    if (v38) {
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
