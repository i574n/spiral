fun spiral_main(): Int {
    val v0: UInt = 1u
    val v1: Int = 0
    val v2: Int = 31
    val v3: UInt = (v0 shl v2)
    val v4: UInt = (v3 shr v2)
    val v5: UInt = (v0 shl v1)
    val v6: Boolean = (v3 == 2147483648u)
    var v8: Boolean = false
    if (v6) {
        val v7: Boolean = (v4 == 1u)
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Boolean = false
    if (v8) {
        val v9: Boolean = (v5 == 1u)
        v10 = v9
    } else {
        v10 = false
    }
    if (v10) {
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
