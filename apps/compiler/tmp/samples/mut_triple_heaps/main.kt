class Heap0(val l0: Int, val l1: String)
class Mut1(var l0: Heap0, var l1: Heap0, var l2: Heap0)
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
    var v6: Int = 0
    v6 = 3
    var v7: String = ""
    v7 = "aa"
    var v8: Heap0 = Heap0(0, "")
    v8 = Heap0(v6, v7)
    var v9: Mut1 = Mut1(Heap0(0, ""), Heap0(0, ""), Heap0(0, ""))
    v9 = Mut1(v2, v5, v8)
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
    var v16: Int = 0
    v16 = 9
    var v17: String = ""
    v17 = "ok"
    var v18: Heap0 = Heap0(0, "")
    v18 = Heap0(v16, v17)
    v9.l0 = v12
    v9.l1 = v15
    v9.l2 = v18
    var v19: Heap0 = Heap0(0, "")
    var v20: Heap0 = Heap0(0, "")
    var v21: Heap0 = Heap0(0, "")
    v19 = v9.l0
    v20 = v9.l1
    v21 = v9.l2
    var v22: Int = 0
    var v23: String = ""
    v22 = v19.l0
    v23 = v19.l1
    var v24: Int = 0
    var v25: String = ""
    v24 = v20.l0
    v25 = v20.l1
    var v26: Int = 0
    var v27: String = ""
    v26 = v21.l0
    v27 = v21.l1
    var v28: Boolean = false
    v28 = (v22 == 7)
    var v30: Boolean = false
    if (v28) {
        var v29: Boolean = false
        v29 = (v23 == "hi")
        v30 = v29
    } else {
        v30 = false
    }
    var v32: Boolean = false
    if (v30) {
        var v31: Boolean = false
        v31 = (v24 == 4)
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Boolean = false
    if (v32) {
        var v33: Boolean = false
        v33 = (v25 == "yo")
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Boolean = false
    if (v34) {
        var v35: Boolean = false
        v35 = (v26 == 9)
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Boolean = false
    if (v36) {
        var v37: Boolean = false
        v37 = (v27 == "ok")
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
