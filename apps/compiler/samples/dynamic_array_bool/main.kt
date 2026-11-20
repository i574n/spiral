fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<Boolean> = emptyArray<Boolean>()
    v1 = Array(v0) { false }
    v1[0] = true
    v1[1] = false
    val v2: Int = 0
    val v3: Boolean = v1[v2]
    if (v3) {
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
