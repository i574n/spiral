class SpiralTuple0(val v0: String, val v1: String)
fun f_c0(v0: String): (Int) -> SpiralTuple0 {
    fun body(v1: Int): SpiralTuple0 {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            var v3: String = ""
            v3 = "no"
            return SpiralTuple0(v3, v3)
        } else {
            var v4: String = ""
            v4 = "yo"
            return SpiralTuple0(v0, v4)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: String = "hi"
    val v1: (Int) -> SpiralTuple0 = f_c0(v0)
    var v2: String = ""
    var v3: String = ""
    val spiral_tuple211 = v1(1)
    v2 = spiral_tuple211.v0
    v3 = spiral_tuple211.v1
    var v4: Boolean = false
    v4 = (v2 == "hi")
    var v6: Boolean = false
    if (v4) {
        val v5: Boolean = (v3 == "yo")
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
