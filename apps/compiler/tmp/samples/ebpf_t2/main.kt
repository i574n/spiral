class SpiralTuple0(val v0: Int, val v1: Int)
class SpiralTuple1(val v0: Int, val v1: Int, val v2: Int)
fun sp_method1(p0: Int, p1: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = p1
    return SpiralTuple0(v0, v1)
}
fun sp_method0(p0: Int, p1: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = 0
    var v3: Int = 0
    val spiral_tuple127 = sp_method1(v0, v1)
    v2 = spiral_tuple127.v0
    v3 = spiral_tuple127.v1
    var v4: Int = 0
    v4 = (v2 + v3)
    return v4
}
fun sp_method3(p0: Int, p1: Int, p2: Int): SpiralTuple1 {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    return SpiralTuple1(v0, v1, v2)
}
fun sp_method2(p0: Int, p1: Int, p2: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = 0
    var v4: Int = 0
    var v5: Int = 0
    val spiral_tuple179 = sp_method3(v0, v1, v2)
    v3 = spiral_tuple179.v0
    v4 = spiral_tuple179.v1
    v5 = spiral_tuple179.v2
    var v6: Int = 0
    v6 = (v3 + v4)
    var v7: Int = 0
    v7 = (v6 + v5)
    return v7
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Int = 0
    v1 = 2
    var v2: Int = 0
    v2 = 3
    var v3: Int = 0
    v3 = sp_method0(v0, v1)
    var v4: Int = 0
    v4 = sp_method2(v0, v1, v2)
    var v5: Int = 0
    v5 = (v3 + v4)
    var v6: Int = 0
    v6 = (v5 - 9)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
