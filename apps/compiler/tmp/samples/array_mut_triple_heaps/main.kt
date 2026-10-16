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
    var v10: Array<Mut1> = emptyArray<Mut1>()
    v10 = Array(1) { Mut1(Heap0(0, ""), Heap0(0, ""), Heap0(0, "")) }
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
    var v17: Int = 0
    v17 = 9
    var v18: String = ""
    v18 = "ok"
    var v19: Heap0 = Heap0(0, "")
    v19 = Heap0(v17, v18)
    var v20: Mut1 = Mut1(Heap0(0, ""), Heap0(0, ""), Heap0(0, ""))
    v20 = v10[0]
    v20.l0 = v13
    v20.l1 = v16
    v20.l2 = v19
    var v21: Heap0 = Heap0(0, "")
    var v22: Heap0 = Heap0(0, "")
    var v23: Heap0 = Heap0(0, "")
    v21 = v20.l0
    v22 = v20.l1
    v23 = v20.l2
    var v24: Int = 0
    var v25: String = ""
    v24 = v21.l0
    v25 = v21.l1
    var v26: Int = 0
    var v27: String = ""
    v26 = v22.l0
    v27 = v22.l1
    var v28: Int = 0
    var v29: String = ""
    v28 = v23.l0
    v29 = v23.l1
    var v30: Boolean = false
    v30 = (v24 == 7)
    var v32: Boolean = false
    if (v30) {
        var v31: Boolean = false
        v31 = (v25 == "hi")
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Boolean = false
    if (v32) {
        var v33: Boolean = false
        v33 = (v26 == 4)
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Boolean = false
    if (v34) {
        var v35: Boolean = false
        v35 = (v27 == "yo")
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Boolean = false
    if (v36) {
        var v37: Boolean = false
        v37 = (v28 == 9)
        v38 = v37
    } else {
        v38 = false
    }
    var v40: Boolean = false
    if (v38) {
        var v39: Boolean = false
        v39 = (v29 == "ok")
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
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
