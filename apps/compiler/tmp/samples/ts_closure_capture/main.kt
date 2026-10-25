fun f_c0(v0: Int, v1: Int): (Int) -> Int {
    fun body(v2: Int): Int {
        var v3: Int = 0
        v3 = (v0 + v1)
        var v4: Int = 0
        v4 = (v3 + v2)
        return v4
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Int = 0
    v1 = 2
    var v2: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v2 = f_c0(v0, v1)
    return v2(39)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
