fun g_c1(v0: Int, v1: Int): (Int) -> Int {
    fun body(v2: Int): Int {
        var v3: Boolean = false
        v3 = (v1 == 0)
        if (v3) {
            return 0
        } else {
            var v4: Int = 0
            v4 = (v2 + v0)
            return v4
        }
    }
    return { p0: Int -> body(p0) }
}
fun f_c0(v0: Int): (Int) -> (Int) -> Int {
    fun body(v1: Int): (Int) -> Int {
        return g_c1(v0, v1)
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: (Int) -> (Int) -> Int = f_c0(v0)
    val v2: (Int) -> Int = v1(1)
    var v3: Int = 0
    v3 = v2(0)
    var v4: Boolean = false
    v4 = (v3 == 7)
    if (v4) {
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
