fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 6
    var v1: Int = 0
    v1 = 7
    var v2: Int = 0
    v2 = (v0 + v1)
    return v2
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
