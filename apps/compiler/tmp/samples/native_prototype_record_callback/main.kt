class SpiralTuple0(val v0: Int, val v1: Int)
fun closure0(v0: Int): (Int, Int) -> SpiralTuple0 {
    fun body(v1: Int, v2: Int): SpiralTuple0 {
        var v3: Int = 0
        v3 = (v1 - 8)
        var v4: Int = 0
        v4 = (v3 + v0)
        var v5: Int = 0
        v5 = (v2 - 18)
        return SpiralTuple0(v4, v5)
    }
    return { p0: Int, p1: Int -> body(p0, p1) }
}
fun sp_method0(p0: (Int, Int) -> SpiralTuple0): SpiralTuple0 {
    var v0: (Int, Int) -> SpiralTuple0 = p0
    return v0(10, 20)
}
fun spiral_main(): Int {
    val v0: Int = 1
    val v1: (Int, Int) -> SpiralTuple0 = closure0(v0)
    var v2: Int = 0
    var v3: Int = 0
    val spiral_tuple206 = sp_method0(v1)
    v2 = spiral_tuple206.v0
    v3 = spiral_tuple206.v1
    var v4: Int = 0
    v4 = (10 + v2)
    var v5: Int = 0
    v5 = (20 + v3)
    val v6: Int = (v4 + v5)
    val v7: Int = (v6 + 7)
    return v7
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
