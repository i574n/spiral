class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(0, "")
    v5 = Heap0(v3, v4)
    var v6: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    v6 = Heap1(v2, v5)
    var v7: Heap0 = Heap0(0, "")
    var v8: Heap0 = Heap0(0, "")
    v7 = v6.l0
    v8 = v6.l1
    var v9: Int = 0
    var v10: String = ""
    v9 = v7.l0
    v10 = v7.l1
    var v11: Int = 0
    var v12: String = ""
    v11 = v8.l0
    v12 = v8.l1
    var v13: Boolean = false
    v13 = (v9 == 7)
    var v15: Boolean = false
    if (v13) {
        var v14: Boolean = false
        v14 = (v10 == "hi")
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Boolean = false
    if (v15) {
        var v16: Boolean = false
        v16 = (v11 == 4)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        var v18: Boolean = false
        v18 = (v12 == "yo")
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
