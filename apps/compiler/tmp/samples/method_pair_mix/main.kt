class SpiralTuple0(val v0: Int, val v1: String)
fun sp_method0(p0: Int, p1: String): SpiralTuple0 {
    var v0: Int = p0
    var v1: String = p1
    var v2: Boolean = false
    v2 = (v0 == 0)
    if (v2) {
        var v3: String = ""
        v3 = "no"
        return SpiralTuple0(0, v3)
    } else {
        return SpiralTuple0(v0, v1)
    }
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    var v2: Int = 0
    var v3: String = ""
    val spiral_tuple145 = sp_method0(v0, v1)
    v2 = spiral_tuple145.v0
    v3 = spiral_tuple145.v1
    val v4: Boolean = (v2 == 7)
    var v6: Boolean = false
    if (v4) {
        val v5: Boolean = (v3 == "hi")
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
