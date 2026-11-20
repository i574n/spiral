fun spiral_main(): Int {
    val v0: Int = 20
    val v1: Int = 2
    val v2: Int = (v0 * v1)
    val v3: Int = (v2 + 3)
    return v3
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
