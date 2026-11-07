class Heap0(val l0: Int, val l1: String)
class Mut1(var l0: Heap0, var l1: Heap0)
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: String = "no"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 2
    val v4: String = "zz"
    val v5: Heap0 = Heap0(v3, v4)
    var v6: Mut1 = Mut1(Heap0(0, ""), Heap0(0, ""))
    v6 = Mut1(v2, v5)
    val v7: Int = 7
    val v8: String = "hi"
    val v9: Heap0 = Heap0(v7, v8)
    val v10: Int = 4
    val v11: String = "yo"
    val v12: Heap0 = Heap0(v10, v11)
    v6.l0 = v9
    v6.l1 = v12
    var v13: Heap0 = Heap0(0, "")
    var v14: Heap0 = Heap0(0, "")
    v13 = v6.l0
    v14 = v6.l1
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
