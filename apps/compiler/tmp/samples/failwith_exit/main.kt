fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Boolean = false
    v1 = (v0 == 1)
    if (v1) {
        System.err.println("bo\$om")
        System.exit(1)
        throw RuntimeException()
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
