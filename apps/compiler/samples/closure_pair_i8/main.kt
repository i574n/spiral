class SpiralTuple0(val v0: Byte, val v1: Byte)
fun f_c0(v0: Byte): (Int) -> SpiralTuple0 {
    fun body(v1: Int): SpiralTuple0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return SpiralTuple0((0).toByte(), (0).toByte())
        } else {
            return SpiralTuple0(v0, (7).toByte())
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Byte = (100).toByte()
    val v1: (Int) -> SpiralTuple0 = f_c0(v0)
    var v2: Byte = (0).toByte()
    var v3: Byte = (0).toByte()
    val spiral_tuple238 = v1(1)
    v2 = spiral_tuple238.v0
    v3 = spiral_tuple238.v1
    val v4: Boolean = (v2 == (100).toByte())
    var v6: Boolean = false
    if (v4) {
        val v5: Boolean = (v3 == (7).toByte())
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
