class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 4
    val v4: String = "yo"
    val v5: Heap0 = Heap0(v3, v4)
    val v6: Heap1 = Heap1(v2, v5)
    val v7: Int = 2
    val v8: Heap2 = Heap2(v6, v7)
    var v9: Array<Heap2> = emptyArray<Heap2>()
    v9 = Array(1) { Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0) }
    v9[0] = v8
    val v10: Heap2 = v9[0]
    var v11: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    var v12: Int = 0
    v11 = v10.l0
    v12 = v10.l1
    var v13: Heap0 = Heap0(0, "")
    var v14: Heap0 = Heap0(0, "")
    v13 = v11.l0
    v14 = v11.l1
    var v15: Int = 0
    var v16: String = ""
    v15 = v13.l0
    v16 = v13.l1
    var v17: Int = 0
    var v18: String = ""
    v17 = v14.l0
    v18 = v14.l1
    val v19: Boolean = (v15 == 7)
    var v21: Boolean = false
    if (v19) {
        val v20: Boolean = (v16 == "hi")
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Boolean = false
    if (v21) {
        val v22: Boolean = (v17 == 4)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        val v24: Boolean = (v18 == "yo")
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        val v26: Boolean = (v12 == 2)
        v27 = v26
    } else {
        v27 = false
    }
    if (v27) {
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
