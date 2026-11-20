fun f_c0(v0: Array<Int>): (Int) -> Int {
    fun body(v1: Int): Int {
        val v2: Int = v0.size
        val v3: Int = (v2 + v1)
        return v3
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Array<Int> = Array(2) { 0 }
    val v1: (Int) -> Int = f_c0(v0)
    return v1(40)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
