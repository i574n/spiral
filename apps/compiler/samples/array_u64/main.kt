fun spiral_main(): Int {
    var v0: Array<ULong> = emptyArray<ULong>()
    v0 = Array(1) { 0uL }
    val v1: ULong = 4294967297uL
    v0[0] = v1
    val v2: ULong = v0[0]
    val v3: Boolean = (v2 == 4294967297uL)
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
