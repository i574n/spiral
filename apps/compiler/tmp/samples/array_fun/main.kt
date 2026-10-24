fun f_c0(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = (v1 + v0)
        return v2
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: (Int) -> Int = f_c0(v0)
    var v2: Int = 0
    v2 = 1
    var v3: Array<(Int) -> Int> = emptyArray<(Int) -> Int>()
    v3 = Array(v2) { { _: Int -> throw RuntimeException() } }
    v3[0] = v1
    val v4: (Int) -> Int = v3[0]
    val v5: Int = v4(4)
    val v6: Boolean = (v5 == 7)
    if (v6) {
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
