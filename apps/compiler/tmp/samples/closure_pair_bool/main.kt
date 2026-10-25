class SpiralTuple0(val v0: Boolean, val v1: Boolean)
fun f_c0(v0: Boolean): (Int) -> SpiralTuple0 {
    fun body(v1: Int): SpiralTuple0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return SpiralTuple0(false, false)
        } else {
            return SpiralTuple0(v0, true)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Boolean = true
    val v1: (Int) -> SpiralTuple0 = f_c0(v0)
    var v2: Boolean = false
    var v3: Boolean = false
    val spiral_tuple223 = v1(1)
    v2 = spiral_tuple223.v0
    v3 = spiral_tuple223.v1
    val v4: Boolean = (v2 && v3)
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
