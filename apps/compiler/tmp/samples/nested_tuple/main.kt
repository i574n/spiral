class SpiralTuple0(val v0: Int, val v1: Int, val v2: Int, val v3: Int)
fun sp_method0(p0: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = 0
    v1 = (v0 + 1)
    var v2: Int = 0
    v2 = (v0 + 2)
    var v3: Int = 0
    v3 = (v0 + 3)
    return SpiralTuple0(v0, v1, v2, v3)
}
fun sp_method1(p0: Int, p1: Int, p2: Int, p3: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    var v4: Int = 0
    v4 = (v0 + v1)
    val v5: Int = (v4 + v2)
    val v6: Int = (v5 + v3)
    val v7: Int = (v6 - 10)
    return v7
}
fun spiral_main(): Int {
    val v0: Int = 1
    var v1: Int = 0
    var v2: Int = 0
    var v3: Int = 0
    var v4: Int = 0
    val spiral_tuple136 = sp_method0(v0)
    v1 = spiral_tuple136.v0
    v2 = spiral_tuple136.v1
    v3 = spiral_tuple136.v2
    v4 = spiral_tuple136.v3
    return sp_method1(v1, v2, v3, v4)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
