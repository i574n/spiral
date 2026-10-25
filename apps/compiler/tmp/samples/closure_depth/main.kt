fun h_c2(v0: Int, v1: Int): (Int) -> Int {
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
fun g_c1(v0: Int, v1: Int): (Int) -> (Int) -> Int {
    fun body(v2: Int): (Int) -> Int {
        return h_c2(v0, v1)
    }
    return { p0: Int -> body(p0) }
}
fun f_c0(v0: Int): (Int) -> (Int) -> (Int) -> Int {
    fun body(v1: Int): (Int) -> (Int) -> Int {
        return g_c1(v0, v1)
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: (Int) -> (Int) -> (Int) -> Int = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: (Int) -> (Int) -> Int = { _: Int -> throw RuntimeException() }
    v2 = v1(1)
    var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v3 = v2(0)
    var v4: Int = 0
    v4 = v3(0)
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
