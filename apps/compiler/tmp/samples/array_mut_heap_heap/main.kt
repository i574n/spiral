class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
class Mut2(var l0: Heap1)
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: String = "no"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 1
    val v4: Heap1 = Heap1(v2, v3)
    val v5: Mut2 = Mut2(v4)
    var v6: Array<Mut2> = emptyArray<Mut2>()
    v6 = Array(1) { Mut2(Heap1(Heap0(0, ""), 0)) }
    v6[0] = v5
    val v7: Int = 7
    val v8: String = "hi"
    val v9: Heap0 = Heap0(v7, v8)
    val v10: Int = 4
    val v11: Heap1 = Heap1(v9, v10)
    var v12: Mut2 = Mut2(Heap1(Heap0(0, ""), 0))
    v12 = v6[0]
    v12.l0 = v11
    val v13: Heap1 = v12.l0
    var v14: Heap0 = Heap0(0, "")
    var v15: Int = 0
    v14 = v13.l0
    v15 = v13.l1
    var v16: Int = 0
    var v17: String = ""
    v16 = v14.l0
    v17 = v14.l1
    val v18: Boolean = (v16 == 7)
    var v20: Boolean = false
    if (v18) {
        val v19: Boolean = (v17 == "hi")
        v20 = v19
    } else {
        v20 = false
    }
    var v22: Boolean = false
    if (v20) {
        val v21: Boolean = (v15 == 4)
        v22 = v21
    } else {
        v22 = false
    }
    if (v22) {
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
