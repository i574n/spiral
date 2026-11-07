fun spiral_main(): Int {
    var v0: Array<Short> = emptyArray<Short>()
    v0 = Array(1) { (0).toShort() }
    val v1: Short = (20000).toShort()
    v0[0] = v1
    val v2: Short = v0[0]
    val v3: Boolean = (v2 == (20000).toShort())
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
