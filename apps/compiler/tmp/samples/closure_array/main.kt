fun f_c0(v0: Int): (Int) -> Array<Int> {
    fun body(v1: Int): Array<Int> {
        var v2: Array<Int> = emptyArray<Int>()
        v2 = Array(1) { 0 }
        v2[0] = v0
        return v2
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: (Int) -> Array<Int> = f_c0(v0)
    var v2: Array<Int> = emptyArray<Int>()
    v2 = v1(1)
    val v3: Int = v2[0]
    val v4: Boolean = (v3 == 7)
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
