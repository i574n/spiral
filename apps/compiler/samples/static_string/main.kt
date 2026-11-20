fun sp_method0(p0: String): Boolean {
    var v0: String = p0
    return true
}
fun spiral_main(): Int {
    val v0: String = "spiral"
    val v1: Boolean = sp_method0(v0)
    if (v1) {
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
