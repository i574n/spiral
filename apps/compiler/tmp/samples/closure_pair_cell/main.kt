class Heap0(val l0: Int)
class SpiralTuple0(val v0: Heap0, val v1: Int)
fun f_c0(v0: Int, v1: Heap0): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            return SpiralTuple0(v1, 0)
        } else {
            return SpiralTuple0(v1, v0)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    val v2: Heap0 = Heap0(v0)
    var v3: (Int) -> SpiralTuple0 = { _: Int -> throw RuntimeException() }
    v3 = f_c0(v1, v2)
    var v4: Heap0 = Heap0(0)
    var v5: Int = 0
    val spiral_tuple281 = v3(1)
    v4 = spiral_tuple281.v0
    v5 = spiral_tuple281.v1
    val v6: Int = v4.l0
    val v7: Int = (v6 + v5)
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
