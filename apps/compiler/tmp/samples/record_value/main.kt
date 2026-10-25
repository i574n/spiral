class SpiralTuple0(val v0: Int, val v1: Int, val v2: Boolean)
fun sp_method0(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = 0
    v1 = (v0 + 2)
    var v2: Boolean = false
    v2 = (v0 > 0)
    return SpiralTuple0(v0, v1, v2)
}
fun sp_method1(p0: Int, p1: Int, p2: Boolean): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Boolean = p2
    if (v2) {
        var v3: Int = 0
        v3 = (v0 + v1)
        var v4: Int = 0
        v4 = (v3 - 4)
        return v4
    } else {
        return 1
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Int = 0
    var v2: Int = 0
    var v3: Boolean = false
    val spiral_tuple130 = sp_method0(v0)
    v1 = spiral_tuple130.v0
    v2 = spiral_tuple130.v1
    v3 = spiral_tuple130.v2
    return sp_method1(v1, v2, v3)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
