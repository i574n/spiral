class SpiralTuple0(val v0: Int, val v1: Int)
fun sp_loop_0(p0: Int, p1: Int, p2: Int, p3: Int): SpiralTuple0 {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    var v4: Boolean = false
    v4 = (v1 >= v0)
    var v9: Int = 0
    var v10: Int = 0
    if (v4) {
        v9 = v2
        v10 = v3
    } else {
        var v5: Int = 0
        v5 = (v1 + 1)
        var v6: Int = 0
        v6 = (v2 + 1)
        var v7: Int = 0
        var v8: Int = 0
        val spiral_tuple458 = sp_loop_0(v0, v5, v6, v3)
        v7 = spiral_tuple458.v0
        v8 = spiral_tuple458.v1
        v9 = v7
        v10 = v8
    }
    return SpiralTuple0(v9, v10)
}
fun spiral_main(): Int {
    val v0: Int = 5
    val v1: Int = 0
    val v2: Int = 1
    val v3: Int = 2
    var v4: Int = 0
    var v5: Int = 0
    val spiral_tuple200 = sp_loop_0(v0, v1, v2, v3)
    v4 = spiral_tuple200.v0
    v5 = spiral_tuple200.v1
    var v6: Int = 0
    v6 = (v4 + v5)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
