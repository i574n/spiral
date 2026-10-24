class SpiralTuple0(val v0: Double, val v1: Double)
fun f_c0(v0: Double): (Int) -> SpiralTuple0 {
    fun body(v1: Int): SpiralTuple0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return SpiralTuple0(0.0, 0.0)
        } else {
            return SpiralTuple0(v0, 2.5)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Double = 1.5
    val v1: (Int) -> SpiralTuple0 = f_c0(v0)
    var v2: Double = 0.0
    var v3: Double = 0.0
    val spiral_tuple213 = v1(1)
    v2 = spiral_tuple213.v0
    v3 = spiral_tuple213.v1
    val v4: Boolean = (v2 == 1.5)
    var v6: Boolean = false
    if (v4) {
        val v5: Boolean = (v3 == 2.5)
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
