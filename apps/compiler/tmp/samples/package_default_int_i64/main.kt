fun spiral_main(): Int {
    val v0: Long = 3000000000L
    val v1: Boolean = (v0 > 2999999999L)
    if (v1) {
        return 7
    } else {
        return 0
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
