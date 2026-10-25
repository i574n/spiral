fun f_c0(v0: Int, v1: Int): (Int) -> Int {
    fun body(v2: Int): Int {
        val v3: Int = (v0 + v1)
        val v4: Int = (v3 + v2)
        return v4
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: Int = 2
    val v2: (Int) -> Int = f_c0(v0, v1)
    return v2(39)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
