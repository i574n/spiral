fun closure1(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = (v0 * 10)
        var v3: Int = 0
        v3 = (v2 + v1)
        return v3
    }
    return { p0: Int -> body(p0) }
}
fun f_c0(): (Int) -> (Int) -> Int {
    fun body(v0: Int): (Int) -> Int {
        return closure1(v0)
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: (Int) -> (Int) -> Int = f_c0()
    val v1: (Int) -> Int = v0(3)
    var v2: Int = 0
    v2 = v1(4)
    var v3: Boolean = false
    v3 = (v2 == 34)
    if (v3) {
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
