class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
class Heap2(val l0: Heap1, val l1: Int)
class Mut3(var l0: Heap2)
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: String = "no"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 1
    val v4: Heap1 = Heap1(v2, v3)
    val v5: Int = 2
    val v6: Heap2 = Heap2(v4, v5)
    var v7: Mut3 = Mut3(Heap2(Heap1(Heap0(0, ""), 0), 0))
    v7 = Mut3(v6)
    val v8: Int = 7
    val v9: String = "hi"
    val v10: Heap0 = Heap0(v8, v9)
    val v11: Int = 4
    val v12: Heap1 = Heap1(v10, v11)
    val v13: Int = 5
    val v14: Heap2 = Heap2(v12, v13)
    v7.l0 = v14
    val v15: Heap2 = v7.l0
    var v16: Heap1 = Heap1(Heap0(0, ""), 0)
    var v17: Int = 0
    v16 = v15.l0
    v17 = v15.l1
    var v18: Heap0 = Heap0(0, "")
    var v19: Int = 0
    v18 = v16.l0
    v19 = v16.l1
    var v20: Int = 0
    var v21: String = ""
    v20 = v18.l0
    v21 = v18.l1
    val v22: Boolean = (v20 == 7)
    var v24: Boolean = false
    if (v22) {
        val v23: Boolean = (v21 == "hi")
        v24 = v23
    } else {
        v24 = false
    }
    var v26: Boolean = false
    if (v24) {
        val v25: Boolean = (v19 == 4)
        v26 = v25
    } else {
        v26 = false
    }
    var v28: Boolean = false
    if (v26) {
        val v27: Boolean = (v17 == 5)
        v28 = v27
    } else {
        v28 = false
    }
    if (v28) {
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
