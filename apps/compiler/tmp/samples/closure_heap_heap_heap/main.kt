class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
class Heap2(val l0: Heap1, val l1: Int)
fun f_c0(v0: Heap2): (Int) -> Heap2 {
    fun body(v1: Int): Heap2 {
        return v0
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 1
    val v4: Heap1 = Heap1(v2, v3)
    val v5: Int = 2
    val v6: Heap2 = Heap2(v4, v5)
    val v7: (Int) -> Heap2 = f_c0(v6)
    val v8: Heap2 = v7(1)
    var v9: Heap1 = Heap1(Heap0(0, ""), 0)
    var v10: Int = 0
    v9 = v8.l0
    v10 = v8.l1
    var v11: Heap0 = Heap0(0, "")
    var v12: Int = 0
    v11 = v9.l0
    v12 = v9.l1
    var v13: Int = 0
    var v14: String = ""
    v13 = v11.l0
    v14 = v11.l1
    val v15: Boolean = (v13 == 7)
    var v17: Boolean = false
    if (v15) {
        val v16: Boolean = (v14 == "hi")
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        val v18: Boolean = (v12 == 1)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        val v20: Boolean = (v10 == 2)
        v21 = v20
    } else {
        v21 = false
    }
    if (v21) {
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
