fun sp_method0(p0: UInt): Boolean {
    var v0: UInt = p0
    var v1: UInt = 0u
    v1 = (v0 + 5u)
    val v2: UInt = (v1 % 4u)
    val v3: Boolean = (v2 == 0u)
    return v3
}
fun spiral_main(): Int {
    val v0: UInt = 7u
    var v1: Boolean = false
    v1 = sp_method0(v0)
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
