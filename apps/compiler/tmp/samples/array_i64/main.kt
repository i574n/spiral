fun spiral_main(): Int {
    var v0: Array<Long> = emptyArray<Long>()
    v0 = Array(1) { 0L }
    var v1: Long = 0L
    v1 = 5000000000L
    v0[0] = v1
    var v2: Long = 0L
    v2 = v0[0]
    var v3: Boolean = false
    v3 = (v2 == 5000000000L)
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
