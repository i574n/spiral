fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Int = 0
    v1 = 5
    var v2: Int = 0
    v2 = v1 * 2
    var v3: Int = 0
    v3 = v0
    var v4: Int = 0
    v4 = (v2 + v3)
    return v4
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
