class Heap0(val l0: Int)
class SpiralTuple0(val v0: Heap0, val v1: Int)
fun sp_method0(p0: Int, p1: Heap0): SpiralTuple0 {
    var v0: Int = p0
    var v1: Heap0 = p1
    return SpiralTuple0(v1, v0)
}
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: Int = 4
    val v2: Heap0 = Heap0(v0)
    var v3: Heap0 = Heap0(0)
    var v4: Int = 0
    val spiral_tuple184 = sp_method0(v1, v2)
    v3 = spiral_tuple184.v0
    v4 = spiral_tuple184.v1
    val v5: Int = v3.l0
    val v6: Int = (v5 + v4)
    val v7: Boolean = (v6 == 7)
    if (v7) {
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
