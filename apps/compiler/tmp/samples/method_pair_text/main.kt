class SpiralTuple0(val v0: String, val v1: String)
fun sp_method0(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = "no"
        return SpiralTuple0(v2, v2)
    } else {
        var v3: String = ""
        v3 = "hi"
        var v4: String = ""
        v4 = "yo"
        return SpiralTuple0(v3, v4)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: String = ""
    var v2: String = ""
    val spiral_tuple109 = sp_method0(v0)
    v1 = spiral_tuple109.v0
    v2 = spiral_tuple109.v1
    var v3: Boolean = false
    v3 = (v1 == "hi")
    var v5: Boolean = false
    if (v3) {
        var v4: Boolean = false
        v4 = (v2 == "yo")
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
