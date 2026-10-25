class Heap0(val l0: Int)
fun f_c0(v0: Heap0): (Int) -> Heap0 {
    fun body(v1: Int): Heap0 {
        return v0
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: Heap0 = Heap0(v0)
    val v2: (Int) -> Heap0 = f_c0(v1)
    val v3: Heap0 = v2(1)
    val v4: Int = v3.l0
    val v5: Boolean = (v4 == 7)
    if (v5) {
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
