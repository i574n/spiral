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
    var v10: Int = 0
    v10 = 7
    var v11: String = ""
    v11 = "hi"
    var v12: Heap0 = Heap0(0, "")
    v12 = Heap0(v10, v11)
    var v13: Int = 0
    v13 = 4
    var v14: String = ""
    v14 = "yo"
    var v15: Heap0 = Heap0(0, "")
    v15 = Heap0(v13, v14)
    var v16: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v16 = Heap1(v12, v15)
    var v17: Int = 0
    v17 = 2
    var v18: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v18 = Heap2(v16, v17)
    v9.l0 = v18
    var v19: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v19 = v9.l0
    var v20: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    var v21: Int = 0
    v20 = v19.l0
    v21 = v19.l1
    var v22: Heap0 = Heap0(0, "")
    var v23: Heap0 = Heap0(0, "")
    v22 = v20.l0
    v23 = v20.l1
    var v24: Int = 0
    var v25: String = ""
    v24 = v22.l0
    v25 = v22.l1
    var v26: Int = 0
    var v27: String = ""
    v26 = v23.l0
    v27 = v23.l1
    var v28: Boolean = false
    v28 = (v24 == 7)
    var v30: Boolean = false
    if (v28) {
        var v29: Boolean = false
        v29 = (v25 == "hi")
        v30 = v29
    } else {
        v30 = false
    }
    var v32: Boolean = false
    if (v30) {
        var v31: Boolean = false
        v31 = (v26 == 4)
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Boolean = false
    if (v32) {
        var v33: Boolean = false
        v33 = (v27 == "yo")
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Boolean = false
    if (v34) {
        var v35: Boolean = false
        v35 = (v21 == 2)
        v36 = v35
    } else {
        v36 = false
    }
    if (v36) {
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
