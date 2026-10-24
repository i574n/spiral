class Heap0(val l0: Int, val l1: String)
class SpiralTuple0(val v0: Heap0, val v1: Heap0)
fun f_c0(v0: Heap0, v1: Heap0): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        return SpiralTuple0(v0, v1)
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 4
    val v4: String = "yo"
    val v5: Heap0 = Heap0(v3, v4)
    val v6: (Int) -> SpiralTuple0 = f_c0(v2, v5)
    var v7: Heap0 = Heap0(0, "")
    var v8: Heap0 = Heap0(0, "")
    val spiral_tuple455 = v6(1)
    v7 = spiral_tuple455.v0
    v8 = spiral_tuple455.v1
    var v9: Int = 0
    var v10: String = ""
    v9 = v7.l0
    v10 = v7.l1
    var v11: Int = 0
    var v12: String = ""
    v11 = v8.l0
    v12 = v8.l1
    val v13: Boolean = (v9 == 7)
    var v15: Boolean = false
    if (v13) {
        val v14: Boolean = (v10 == "hi")
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Boolean = false
    if (v15) {
        val v16: Boolean = (v11 == 4)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        val v18: Boolean = (v12 == "yo")
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
