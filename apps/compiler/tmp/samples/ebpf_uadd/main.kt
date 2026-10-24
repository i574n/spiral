fun spiral_main(): Int {
    val v0: UInt = 2147483647u
    val v1: UInt = 2u
    val v2: UInt = 1u
    val v3: UInt = (v0 + v1)
    val v4: UInt = (v0 + v2)
    val v5: Boolean = (v3 == 2147483649u)
    var v7: Boolean = false
    if (v5) {
        val v6: Boolean = (v4 == 2147483648u)
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
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
