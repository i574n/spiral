class SpiralTuple0(val v0: Float, val v1: String)
fun f_c0(v0: Float, v1: String): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            return SpiralTuple0(0.0f, v4)
        } else {
            return SpiralTuple0(v0, v1)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Float = 1.5f
    val v1: String = "hi"
    val v2: (Int) -> SpiralTuple0 = f_c0(v0, v1)
    var v3: Float = 0.0f
    var v4: String = ""
    val spiral_tuple248 = v2(1)
    v3 = spiral_tuple248.v0
    v4 = spiral_tuple248.v1
    val v5: Boolean = (v3 == 1.5f)
    var v7: Boolean = false
    if (v5) {
        val v6: Boolean = (v4 == "hi")
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
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
