class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
class Heap2(val l0: Heap1, val l1: Int)
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 1
    val v4: Heap1 = Heap1(v2, v3)
    val v5: Int = 2
    val v6: Heap2 = Heap2(v4, v5)
    var v7: Heap1 = Heap1(Heap0(0, ""), 0)
    var v8: Int = 0
    v7 = v6.l0
    v8 = v6.l1
    var v9: Heap0 = Heap0(0, "")
    var v10: Int = 0
    v9 = v7.l0
    v10 = v7.l1
    var v11: Int = 0
    var v12: String = ""
    v11 = v9.l0
    v12 = v9.l1
    val v13: Boolean = (v11 == 7)
    var v15: Boolean = false
    if (v13) {
        val v14: Boolean = (v12 == "hi")
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Boolean = false
    if (v15) {
        val v16: Boolean = (v10 == 1)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        val v18: Boolean = (v8 == 2)
        v19 = v18
    } else {
        v19 = false
    }
    if (v19) {
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
