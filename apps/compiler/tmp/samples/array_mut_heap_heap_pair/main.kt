class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
class Mut3(var l0: Heap2)
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: String = "no"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 2
    val v4: String = "zz"
    val v5: Heap0 = Heap0(v3, v4)
    val v6: Heap1 = Heap1(v2, v5)
    val v7: Int = 3
    val v8: Heap2 = Heap2(v6, v7)
    val v9: Mut3 = Mut3(v8)
    var v10: Array<Mut3> = emptyArray<Mut3>()
    v10 = Array(1) { Mut3(Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)) }
    v10[0] = v9
    val v11: Int = 7
    val v12: String = "hi"
    val v13: Heap0 = Heap0(v11, v12)
    val v14: Int = 4
    val v15: String = "yo"
    val v16: Heap0 = Heap0(v14, v15)
    val v17: Heap1 = Heap1(v13, v16)
    val v18: Int = 2
    val v19: Heap2 = Heap2(v17, v18)
    var v20: Mut3 = Mut3(Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0))
    v20 = v10[0]
    v20.l0 = v19
    val v21: Heap2 = v20.l0
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
    val v30: Boolean = (v26 == 7)
    var v32: Boolean = false
    if (v30) {
        val v31: Boolean = (v27 == "hi")
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Boolean = false
    if (v32) {
        val v33: Boolean = (v28 == 4)
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Boolean = false
    if (v34) {
        val v35: Boolean = (v29 == "yo")
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Boolean = false
    if (v36) {
        val v37: Boolean = (v23 == 2)
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
