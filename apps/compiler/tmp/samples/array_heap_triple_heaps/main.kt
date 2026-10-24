class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0, val l2: Heap0)
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 4
    val v4: String = "yo"
    val v5: Heap0 = Heap0(v3, v4)
    val v6: Int = 9
    val v7: String = "ok"
    val v8: Heap0 = Heap0(v6, v7)
    val v9: Heap1 = Heap1(v2, v5, v8)
    var v10: Array<Heap1> = emptyArray<Heap1>()
    v10 = Array(1) { Heap1(Heap0(0, ""), Heap0(0, ""), Heap0(0, "")) }
    v10[0] = v9
    val v11: Heap1 = v10[0]
    var v12: Heap0 = Heap0(0, "")
    var v13: Heap0 = Heap0(0, "")
    var v14: Heap0 = Heap0(0, "")
    v12 = v11.l0
    v13 = v11.l1
    v14 = v11.l2
    var v15: Int = 0
    var v16: String = ""
    v15 = v12.l0
    v16 = v12.l1
    var v17: Int = 0
    var v18: String = ""
    v17 = v13.l0
    v18 = v13.l1
    var v19: Int = 0
    var v20: String = ""
    v19 = v14.l0
    v20 = v14.l1
    val v21: Boolean = (v15 == 7)
    var v23: Boolean = false
    if (v21) {
        val v22: Boolean = (v16 == "hi")
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        val v24: Boolean = (v17 == 4)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        val v26: Boolean = (v18 == "yo")
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        val v28: Boolean = (v19 == 9)
        v29 = v28
    } else {
        v29 = false
    }
    var v31: Boolean = false
    if (v29) {
        val v30: Boolean = (v20 == "ok")
        v31 = v30
    } else {
        v31 = false
    }
    if (v31) {
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
