fun spiral_main(): Int {
    val v0: UInt = 4294967295u
    val v1: UInt = 15u
    val v2: UInt = (v0 and v1)
    val v3: UInt = (v0 or v1)
    val v4: UInt = (v0 xor v1)
    val v5: UInt = (v1.inv())
    val v6: Boolean = (v2 == 15u)
    var v8: Boolean = false
    if (v6) {
        val v7: Boolean = (v3 == v0)
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Boolean = false
    if (v8) {
        val v9: Boolean = (v4 == v5)
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Boolean = false
    if (v10) {
        val v11: Boolean = (v5 == 4294967280u)
        v12 = v11
    } else {
        v12 = false
    }
    if (v12) {
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
