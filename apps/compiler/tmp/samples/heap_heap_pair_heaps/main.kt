class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Heap0)
class Heap2(val l0: Heap1, val l1: Int)
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
    var v7: Int = 0
    v7 = 2
    var v8: Heap2 = Heap2(Heap1(Heap0(0, ""), Heap0(0, "")), 0)
    v8 = Heap2(v6, v7)
    var v9: Heap1 = Heap1(Heap0(0, ""), Heap0(0, ""))
    var v10: Int = 0
    v9 = v8.l0
    v10 = v8.l1
    var v11: Heap0 = Heap0(0, "")
    var v12: Heap0 = Heap0(0, "")
    v11 = v9.l0
    v12 = v9.l1
    var v13: Int = 0
    var v14: String = ""
    v13 = v11.l0
    v14 = v11.l1
    var v15: Int = 0
    var v16: String = ""
    v15 = v12.l0
    v16 = v12.l1
    var v17: Boolean = false
    v17 = (v13 == 7)
    var v19: Boolean = false
    if (v17) {
        var v18: Boolean = false
        v18 = (v14 == "hi")
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        var v20: Boolean = false
        v20 = (v15 == 4)
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Boolean = false
    if (v21) {
        var v22: Boolean = false
        v22 = (v16 == "yo")
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        var v24: Boolean = false
        v24 = (v10 == 2)
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
