fun spiral_main(): Int {
    val v0: Int = -3
    val v1: Int = -4
    val v2: Int = -3
    val v3: UInt = 4294967295u
    val v4: UInt = 0u
    val v5: UInt = 4294967295u
    val v6: Float = -1.5f
    val v7: Float = -0.5f
    val v8: Float = -1.5f
    val v9: Boolean = (v0 != v1)
    val v10: Boolean = (v0 != v2)
    val v11: Boolean = (v3 != v4)
    val v12: Boolean = (v3 != v5)
    val v13: Boolean = (v6 != v7)
    val v14: Boolean = (v6 != v8)
    val v15: Boolean = (v9 && v11)
    val v16: Boolean = (v15 && v13)
    if (v16) {
        if (v10) {
            return 1
        } else {
            if (v12) {
                return 2
            } else {
                if (v14) {
                    return 3
                } else {
                    return 0
                }
            }
        }
    } else {
        return 4
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
