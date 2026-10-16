fun spiral_main(): Int {
    var v1: Int = 0
    v1 = 42
    var v3: Int = 0
    v3 = (v1 - 42)
    return v3
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
