class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 1
    val v4: Heap1 = Heap1(v2, v3)
    var v5: Array<Heap1> = emptyArray<Heap1>()
    v5 = Array(1) { Heap1(Heap0(0, ""), 0) }
    v5[0] = v4
    val v6: Heap1 = v5[0]
    var v7: Heap0 = Heap0(0, "")
    var v8: Int = 0
    v7 = v6.l0
    v8 = v6.l1
    var v9: Int = 0
    var v10: String = ""
    v9 = v7.l0
    v10 = v7.l1
    val v11: Boolean = (v9 == 7)
    var v13: Boolean = false
    if (v11) {
        val v12: Boolean = (v10 == "hi")
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Boolean = false
    if (v13) {
        val v14: Boolean = (v8 == 1)
        v15 = v14
    } else {
        v15 = false
    }
    if (v15) {
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
