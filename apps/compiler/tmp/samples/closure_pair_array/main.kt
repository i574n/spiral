class SpiralTuple0(val v0: Array<Int>, val v1: Array<Int>)
fun f_c0(v0: Int, v1: Int): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Array<Int> = emptyArray<Int>()
        v3 = Array(1) { 0 }
        var v4: Array<Int> = emptyArray<Int>()
        v4 = Array(1) { 0 }
        var v5: Boolean = false
        v5 = (v2 == 0)
        if (v5) {
            v3[0] = 0
            v4[0] = 0
            return SpiralTuple0(v3, v4)
        } else {
            v3[0] = v0
            v4[0] = v1
            return SpiralTuple0(v3, v4)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    val v2: (Int) -> SpiralTuple0 = f_c0(v0, v1)
    var v3: Array<Int> = emptyArray<Int>()
    var v4: Array<Int> = emptyArray<Int>()
    val spiral_tuple270 = v2(1)
    v3 = spiral_tuple270.v0
    v4 = spiral_tuple270.v1
    var v5: Int = 0
    v5 = v3[0]
    val v6: Int = v4[0]
    val v7: Int = (v5 + v6)
    val v8: Boolean = (v7 == 7)
    if (v8) {
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
