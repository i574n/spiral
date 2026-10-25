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
    val v0: Int = 1
    val v1: Int = 2
    val v2: (Int) -> Int = f_c0(v0, v1)
    var v3: Int = 0
    v3 = v2(10)
    var v4: Int = 0
    v4 = v2(20)
    val v5: Int = v2(3)
    val v6: Int = (v3 + v4)
    val v7: Int = (v6 + v5)
    return v7
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
