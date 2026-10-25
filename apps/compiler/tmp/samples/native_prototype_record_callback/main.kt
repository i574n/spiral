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
    var v0: Int = 0
    v0 = 1
    var v1: (Int, Int) -> SpiralTuple0 = { _: Int, _: Int -> throw RuntimeException() }
    v1 = closure0(v0)
    var v2: Int = 0
    var v3: Int = 0
    val spiral_tuple213 = sp_method0(v1)
    v2 = spiral_tuple213.v0
    v3 = spiral_tuple213.v1
    var v4: Int = 0
    v4 = (10 + v2)
    var v5: Int = 0
    v5 = (20 + v3)
    var v6: Int = 0
    v6 = (v4 + v5)
    var v7: Int = 0
    v7 = (v6 + 7)
    return v7
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
