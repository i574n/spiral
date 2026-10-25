class SpiralTuple0(val v0: Int, val v1: Int)
fun sp_method0(p0: Int, p1: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = p1
    return SpiralTuple0(v0, v1)
}
fun sp_method1(p0: Int, p1: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = (v0 + v1)
    return v2
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 20
    var v1: Int = 0
    v1 = 22
    var v2: Int = 0
    var v3: Int = 0
    val spiral_tuple136 = sp_method0(v0, v1)
    v2 = spiral_tuple136.v0
    v3 = spiral_tuple136.v1
    var v4: Int = 0
    v4 = sp_method1(v2, v3)
    var v5: Int = 0
    v5 = (v4 - 42)
    return v5
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
