fun spiral_main(): Int {
    val v0: Int = 6
    val v1: Int = 7
    val v2: Int = (v0 * v1)
    val v3: Boolean = (v2 == 42)
    if (v3) {
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
