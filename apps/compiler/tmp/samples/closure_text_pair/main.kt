class SpiralTuple0(val v0: String, val v1: String)
fun f_c0(v0: String, v1: String): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            var v5: String = ""
            v5 = "nay"
            return SpiralTuple0(v4, v5)
        } else {
            return SpiralTuple0(v0, v1)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "hi"
    var v1: String = ""
    v1 = "yo"
    var v2: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v2 = f_c0(v0, v1)
    var v3: String = ""
    var v4: String = ""
    val spiral_tuple255 = v2(1)
    v3 = spiral_tuple255.v0
    v4 = spiral_tuple255.v1
    var v5: Boolean = false
    v5 = (v3 == "hi")
    var v7: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v4 == "yo")
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
