class Heap0(val l0: Int)
fun sp_method0(p0: Heap0): Heap0 {
    var v0: Heap0 = p0
    return v0
}
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: Heap0 = Heap0(v0)
    val v2: Heap0 = sp_method0(v1)
    val v3: Int = v2.l0
    val v4: Boolean = (v3 == 7)
    if (v4) {
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
