fun f_c0(): (Int) -> Int {
    fun body(v0: Int): Int {
        var v1: Int = 0
        v1 = (v0 + 1)
        return v1
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v0 = f_c0()
    var v1: Int = 0
    v1 = v0(6)
    var v2: Boolean = false
    v2 = (v1 == 7)
    if (v2) {
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
