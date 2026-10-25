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
    var v9: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    var v10: Int = 0
    v9 = v8.l0
    v10 = v8.l1
    var v11: Heap0 = Heap0(0, "")
    var v12: Heap0 = Heap0(0, "")
    v11 = v9.l0
    v12 = v9.l1
    var v13: Int = 0
    var v14: String = ""
    v13 = v11.l0
    v14 = v11.l1
    var v15: Int = 0
    var v16: String = ""
    v15 = v12.l0
    v16 = v12.l1
    val v17: Boolean = (v13 == 7)
    var v19: Boolean = false
    if (v17) {
        val v18: Boolean = (v14 == "hi")
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        val v20: Boolean = (v15 == 4)
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Boolean = false
    if (v21) {
        val v22: Boolean = (v16 == "yo")
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        val v24: Boolean = (v10 == 2)
        v25 = v24
    } else {
        v25 = false
    }
    if (v25) {
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
