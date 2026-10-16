class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
class Mut2(var l0: Heap1)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: String = ""
    v1 = "no"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    v3 = 1
    var v4: Heap1 = Heap1(Heap0(0, ""), 0)
    v4 = Heap1(v2, v3)
    var v5: Mut2 = Mut2(Heap1(Heap0(0, ""), 0))
    v5 = Mut2(v4)
    var v6: Array<Mut2> = emptyArray<Mut2>()
    v6 = Array(1) { Mut2(Heap1(Heap0(0, ""), 0)) }
    v6[0] = v5
    var v7: Int = 0
    v7 = 7
    var v8: String = ""
    v8 = "hi"
    var v9: Heap0 = Heap0(0, "")
    v9 = Heap0(v7, v8)
    var v10: Int = 0
    v10 = 4
    var v11: Heap1 = Heap1(Heap0(0, ""), 0)
    v11 = Heap1(v9, v10)
    var v12: Mut2 = Mut2(Heap1(Heap0(0, ""), 0))
    v12 = v6[0]
    v12.l0 = v11
    var v13: Heap1 = Heap1(Heap0(0, ""), 0)
    v13 = v12.l0
    var v14: Heap0 = Heap0(0, "")
    var v15: Int = 0
    v14 = v13.l0
    v15 = v13.l1
    var v16: Int = 0
    var v17: String = ""
    v16 = v14.l0
    v17 = v14.l1
    var v18: Boolean = false
    v18 = (v16 == 7)
    var v20: Boolean = false
    if (v18) {
        var v19: Boolean = false
        v19 = (v17 == "hi")
        v20 = v19
    } else {
        v20 = false
    }
    var v22: Boolean = false
    if (v20) {
        var v21: Boolean = false
        v21 = (v15 == 4)
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
