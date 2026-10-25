class SpiralTuple0(val v0: Int, val v1: Int)
fun f_c0(): (Int) -> SpiralTuple0 {
    fun body(v0: Int): SpiralTuple0 {
        var v1: Int = 0
        v1 = (v0 + 1)
        return SpiralTuple0(v0, v1)
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v1 = f_c0()
    var v2: Int = 0
    var v3: Int = 0
    val spiral_tuple194 = v1(v0)
    v2 = spiral_tuple194.v0
    v3 = spiral_tuple194.v1
    var v4: Boolean = false
    v4 = (v2 == 3)
    var v6: Boolean = false
    if (v4) {
        var v5: Boolean = false
        v5 = (v3 == 4)
        v6 = v5
    } else {
        v6 = false
    }
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
