class Heap0(val l0: Int)
class SpiralTuple0(val v0: Heap0, val v1: Heap0)
fun sp_method0(p0: Heap0, p1: Heap0): SpiralTuple0 {
    var v0: Heap0 = p0
    var v1: Heap0 = p1
    return SpiralTuple0(v0, v1)
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    val v2: Heap0 = Heap0(v0)
    val v3: Heap0 = Heap0(v1)
    var v4: Heap0 = Heap0(0)
    var v5: Heap0 = Heap0(0)
    val spiral_tuple252 = sp_method0(v2, v3)
    v4 = spiral_tuple252.v0
    v5 = spiral_tuple252.v1
    val v6: Int = v4.l0
    val v7: Int = v5.l0
    val v8: Int = (v6 + v7)
    val v9: Boolean = (v8 == 7)
    if (v9) {
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
