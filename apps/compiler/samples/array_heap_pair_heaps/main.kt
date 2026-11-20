class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 4
    val v4: String = "yo"
    val v5: Heap0 = Heap0(v3, v4)
    val v6: Heap1 = Heap1(v2, v5)
    var v7: Array<Heap1> = emptyArray<Heap1>()
    v7 = Array(1) { Heap1(Heap0(0, ""), Heap0(0, "")) }
    v7[0] = v6
    val v8: Heap1 = v7[0]
    var v9: Heap0 = Heap0(0, "")
    var v10: Heap0 = Heap0(0, "")
    v9 = v8.l0
    v10 = v8.l1
    var v11: Int = 0
    var v12: String = ""
    v11 = v9.l0
    v12 = v9.l1
    var v13: Int = 0
    var v14: String = ""
    v13 = v10.l0
    v14 = v10.l1
    val v15: Boolean = (v11 == 7)
    var v17: Boolean = false
    if (v15) {
        val v16: Boolean = (v12 == "hi")
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        val v18: Boolean = (v13 == 4)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        val v20: Boolean = (v14 == "yo")
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
