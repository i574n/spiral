class Heap0(val l0: Int, val l1: String)
class Mut1(var l0: Heap0, var l1: Heap0)
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: String = "no"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 2
    val v4: String = "zz"
    val v5: Heap0 = Heap0(v3, v4)
    val v6: Mut1 = Mut1(v2, v5)
    var v7: Array<Mut1> = emptyArray<Mut1>()
    v7 = Array(1) { Mut1(Heap0(0, ""), Heap0(0, "")) }
    v7[0] = v6
    val v8: Int = 7
    val v9: String = "hi"
    val v10: Heap0 = Heap0(v8, v9)
    val v11: Int = 4
    val v12: String = "yo"
    val v13: Heap0 = Heap0(v11, v12)
    var v14: Mut1 = Mut1(Heap0(0, ""), Heap0(0, ""))
    v14 = v7[0]
    v14.l0 = v10
    v14.l1 = v13
    var v15: Heap0 = Heap0(0, "")
    var v16: Heap0 = Heap0(0, "")
    v15 = v14.l0
    v16 = v14.l1
    var v17: Int = 0
    var v18: String = ""
    v17 = v15.l0
    v18 = v15.l1
    var v19: Int = 0
    var v20: String = ""
    v19 = v16.l0
    v20 = v16.l1
    val v21: Boolean = (v17 == 7)
    var v23: Boolean = false
    if (v21) {
        val v22: Boolean = (v18 == "hi")
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        val v24: Boolean = (v19 == 4)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        val v26: Boolean = (v20 == "yo")
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
