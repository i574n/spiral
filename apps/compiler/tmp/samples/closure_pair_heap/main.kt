class Heap0(val l0: Int)
class SpiralTuple0(val v0: Heap0, val v1: Heap0)
fun f_c0(v0: Heap0, v1: Heap0): (Int) -> SpiralTuple0 {
    fun body(v2: Int): SpiralTuple0 {
        var v3: Boolean = false
        v3 = (v2 == 0)
        if (v3) {
            return SpiralTuple0(v1, v0)
        } else {
            return SpiralTuple0(v0, v1)
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    val v2: Heap0 = Heap0(v0)
    var v3: Heap0 = Heap0(0)
    v3 = Heap0(v1)
    val v4: (Int) -> SpiralTuple0 = f_c0(v2, v3)
    var v5: Heap0 = Heap0(0)
    var v6: Heap0 = Heap0(0)
    val spiral_tuple338 = v4(1)
    v5 = spiral_tuple338.v0
    v6 = spiral_tuple338.v1
    val v7: Int = v5.l0
    val v8: Int = v6.l0
    val v9: Int = (v7 + v8)
    val v10: Boolean = (v9 == 7)
    if (v10) {
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
