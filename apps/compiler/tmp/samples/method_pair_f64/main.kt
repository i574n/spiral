class SpiralTuple0(val v0: Double, val v1: Double)
fun sp_method0(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        return SpiralTuple0(0.0, 0.0)
    } else {
        return SpiralTuple0(1.5, 2.5)
    }
}
fun spiral_main(): Int {
    val v0: Int = 7
    var v1: Double = 0.0
    var v2: Double = 0.0
    val spiral_tuple106 = sp_method0(v0)
    v1 = spiral_tuple106.v0
    v2 = spiral_tuple106.v1
    val v3: Boolean = (v1 == 1.5)
    var v5: Boolean = false
    if (v3) {
        val v4: Boolean = (v2 == 2.5)
        v5 = v4
    } else {
        v5 = false
    }
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
