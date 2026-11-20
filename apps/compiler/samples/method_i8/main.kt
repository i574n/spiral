fun sp_method0(p0: Byte): Byte {
    var v0: Byte = p0
    var v1: Boolean = false
    v1 = (v0 == (0).toByte())
    if (v1) {
        return (1).toByte()
    } else {
        return v0
    }
}
fun spiral_main(): Int {
    val v0: Byte = (100).toByte()
    var v1: Byte = (0).toByte()
    v1 = sp_method0(v0)
    val v2: Boolean = (v1 == (100).toByte())
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
