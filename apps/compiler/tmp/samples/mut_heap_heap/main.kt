class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
class Mut2(var l0: Heap1)
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: String = "no"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 1
    val v4: Heap1 = Heap1(v2, v3)
    var v5: Mut2 = Mut2(Heap1(Heap0(0, ""), 0))
    v5 = Mut2(v4)
    val v6: Int = 7
    val v7: String = "hi"
    val v8: Heap0 = Heap0(v6, v7)
    val v9: Int = 4
    val v10: Heap1 = Heap1(v8, v9)
    v5.l0 = v10
    val v11: Heap1 = v5.l0
    var v12: Heap0 = Heap0(0, "")
    var v13: Int = 0
    v12 = v11.l0
    v13 = v11.l1
    var v14: Int = 0
    var v15: String = ""
    v14 = v12.l0
    v15 = v12.l1
    val v16: Boolean = (v14 == 7)
    var v18: Boolean = false
    if (v16) {
        val v17: Boolean = (v15 == "hi")
        v18 = v17
    } else {
        v18 = false
    }
    var v20: Boolean = false
    if (v18) {
        val v19: Boolean = (v13 == 4)
        v20 = v19
    } else {
        v20 = false
    }
    if (v20) {
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
