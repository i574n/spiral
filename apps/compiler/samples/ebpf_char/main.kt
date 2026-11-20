fun spiral_main(): Int {
    val v0: Int = 65
    val v1: Int = 66
    val v2: Boolean = (v0 == 65)
    if (v2) {
        val v3: Boolean = (v1 == 66)
        if (v3) {
            val v4: Boolean = (v0 == v1)
            if (v4) {
                return 2
            } else {
                return 0
            }
        } else {
            return 3
        }
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
