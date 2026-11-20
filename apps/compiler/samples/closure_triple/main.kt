class SpiralTuple0(val v0: Int, val v1: String, val v2: Boolean)
fun f_c0(v0: Int, v1: String, v2: Boolean): (Int) -> SpiralTuple0 {
    fun body(v3: Int): SpiralTuple0 {
        var v4: Boolean = false
        v4 = (v3 == 0)
        if (v4) {
            var v5: String = ""
            v5 = "no"
            return SpiralTuple0(0, v5, false)
        } else {
            return SpiralTuple0(v0, v1, v2)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Boolean = true
    val v3: (Int) -> SpiralTuple0 = f_c0(v0, v1, v2)
    var v4: Int = 0
    var v5: String = ""
    var v6: Boolean = false
    val spiral_tuple309 = v3(1)
    v4 = spiral_tuple309.v0
    v5 = spiral_tuple309.v1
    v6 = spiral_tuple309.v2
    val v7: Boolean = (v4 == 7)
    var v9: Boolean = false
    if (v7) {
        val v8: Boolean = (v5 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    val v10: Boolean = (v9 && v6)
    if (v10) {
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
