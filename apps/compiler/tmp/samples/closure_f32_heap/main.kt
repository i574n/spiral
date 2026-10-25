class Heap0(val l0: Float, val l1: String)
fun f_c0(v0: Heap0): (Int) -> Heap0 {
    fun body(v1: Int): Heap0 {
        return v0
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Float = 1.5f
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: (Int) -> Heap0 = f_c0(v2)
    val v4: Heap0 = v3(1)
    var v5: Float = 0.0f
    var v6: String = ""
    v5 = v4.l0
    v6 = v4.l1
    val v7: Boolean = (v5 == 1.5f)
    var v9: Boolean = false
    if (v7) {
        val v8: Boolean = (v6 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
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
