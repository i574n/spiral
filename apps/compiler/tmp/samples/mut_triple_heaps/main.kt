class Heap0(val l0: Int, val l1: String)
class Mut1(var l0: Heap0, var l1: Heap0, var l2: Heap0)
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: String = "no"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 2
    val v4: String = "zz"
    val v5: Heap0 = Heap0(v3, v4)
    val v6: Int = 3
    val v7: String = "aa"
    val v8: Heap0 = Heap0(v6, v7)
    var v9: Mut1 = Mut1(Heap0(0, ""), Heap0(0, ""), Heap0(0, ""))
    v9 = Mut1(v2, v5, v8)
    val v10: Int = 7
    val v11: String = "hi"
    val v12: Heap0 = Heap0(v10, v11)
    val v13: Int = 4
    val v14: String = "yo"
    val v15: Heap0 = Heap0(v13, v14)
    val v16: Int = 9
    val v17: String = "ok"
    val v18: Heap0 = Heap0(v16, v17)
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
    val v28: Boolean = (v22 == 7)
    var v30: Boolean = false
    if (v28) {
        val v29: Boolean = (v23 == "hi")
        v30 = v29
    } else {
        v30 = false
    }
    var v32: Boolean = false
    if (v30) {
        val v31: Boolean = (v24 == 4)
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Boolean = false
    if (v32) {
        val v33: Boolean = (v25 == "yo")
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Boolean = false
    if (v34) {
        val v35: Boolean = (v26 == 9)
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Boolean = false
    if (v36) {
        val v37: Boolean = (v27 == "ok")
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
