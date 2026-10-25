fun spiral_main(): Int {
    var v0: Long = 0L
    v0 = 3000000000L
    var v1: Boolean = false
    v1 = (v0 > 2999999999L)
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
