fun a_c0(): (Int) -> Int {
    fun body(v0: Int): Int {
        var v1: Int = 0
        v1 = (v0 + 2)
        return v1
    }
    return { p0: Int -> body(p0) }
}
fun b_c1(): (Int) -> Int {
    fun body(v0: Int): Int {
        var v1: Int = 0
        v1 = (v0 + 3)
        return v1
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> Int): Int {
    var v0: (Int) -> Int = p0
    return v0(40)
}
fun spiral_main(): Int {
    val v0: Boolean = true
    var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
    if (v0) {
        v3 = a_c0()
    } else {
        v3 = b_c1()
    }
    return sp_method0(v3)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
