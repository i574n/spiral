class Heap0(val l0: Int, val l1: Int)
fun spiral_main(): Int {
    val v0: Heap0 = Heap0(9, 10)
    val v1: Int = v0.l0
    val v2: Int = v0.l1
    val v3: Int = (v1 + v2)
    return v3
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
