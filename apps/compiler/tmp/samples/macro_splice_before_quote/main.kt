fun spiral_main(): Int {
    val v0: Int = 7
    val v1: Int = 5
    val v2: Int = v1 * 2
    val v3: Int = v0
    val v4: Int = (v2 + v3)
    return v4
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
