class Heap0(val l0: Int, val l1: Int)
fun spiral_main(): Int {
    var v0: Heap0 = Heap0(0, 0)
    v0 = Heap0(9, 10)
    var v1: Int = 0
    v1 = v0.l0
    var v2: Int = 0
    v2 = v0.l1
    var v3: Int = 0
    v3 = (v1 + v2)
    return v3
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
