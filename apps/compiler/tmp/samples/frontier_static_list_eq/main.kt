fun spiral_main(): Int {
    val v0: Int = 120
    val v1: Boolean = (v0 == 32)
    var v3: Boolean = false
    if (v1) {
        v3 = true
    } else {
        val v2: Boolean = (v0 == 47)
        v3 = v2
    }
    if (v3) {
        return 1
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
