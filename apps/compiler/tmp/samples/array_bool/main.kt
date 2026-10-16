fun spiral_main(): Int {
    var v0: Array<Boolean> = emptyArray<Boolean>()
    v0 = Array(1) { false }
    var v1: Boolean = false
    v1 = true
    v0[0] = v1
    var v2: Boolean = false
    v2 = v0[0]
    if (v2) {
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
