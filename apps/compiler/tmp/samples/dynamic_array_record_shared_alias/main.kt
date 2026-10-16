class SpiralTuple0(val v0: Array<Int>, val v1: Int)
fun sp_method0(): SpiralTuple0 {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 3
    v1[1] = 4
    return SpiralTuple0(v1, 1)
}
fun sp_method1(p0: Array<Int>, p1: Int): Int {
    var v0: Array<Int> = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = v0[0]
    var v3: Int = 0
    v3 = (v2 + v1)
    var v4: Int = 0
    v4 = (v3 - 1)
    return v4
}
fun sp_method2(p0: Array<Int>, p1: Int): Int {
    var v0: Array<Int> = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = v0[0]
    var v3: Int = 0
    v3 = v0[1]
    var v4: Int = 0
    v4 = (v2 + v3)
    var v5: Int = 0
    v5 = (v4 + v1)
    return v5
}
fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    var v1: Int = 0
    val spiral_tuple91 = sp_method0()
    v0 = spiral_tuple91.v0
    v1 = spiral_tuple91.v1
    var v2: Int = 0
    v2 = sp_method1(v0, v1)
    var v3: Int = 0
    v3 = sp_method2(v0, v1)
    var v4: Int = 0
    v4 = (v2 + v3)
    var v5: Int = 0
    v5 = (v4 - 11)
    return v5
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
