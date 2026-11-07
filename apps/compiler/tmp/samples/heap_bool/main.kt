class Heap0(val l0: Boolean)
fun spiral_main(): Int {
    val v0: Boolean = true
    val v1: Heap0 = Heap0(v0)
    val v2: Boolean = v1.l0
    if (v2) {
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
