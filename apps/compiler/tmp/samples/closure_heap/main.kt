class Heap0(val l0: Int)
fun f_c0(v0: Heap0): (Int) -> Heap0 {
    fun body(v1: Int): Heap0 {
        return v0
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Heap0 = Heap0(0)
    v1 = Heap0(v0)
    var v2: (Int) -> Heap0 = { _: Int -> throw RuntimeException() }
    v2 = f_c0(v1)
    var v3: Heap0 = Heap0(0)
    v3 = v2(1)
    var v4: Int = 0
    v4 = v3.l0
    var v5: Boolean = false
    v5 = (v4 == 7)
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
