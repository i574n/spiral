fun spiral_main(): Int {
    var v0: Int = 0
    v0 = -3
    var v1: Int = 0
    v1 = -4
    var v2: Int = 0
    v2 = -3
    var v3: UInt = 0u
    v3 = 4294967295u
    var v4: UInt = 0u
    v4 = 0u
    var v5: UInt = 0u
    v5 = 4294967295u
    var v6: Float = 0.0f
    v6 = -1.5f
    var v7: Float = 0.0f
    v7 = -0.5f
    var v8: Float = 0.0f
    v8 = -1.5f
    var v9: Boolean = false
    v9 = (v0 != v1)
    var v10: Boolean = false
    v10 = (v0 != v2)
    var v11: Boolean = false
    v11 = (v3 != v4)
    var v12: Boolean = false
    v12 = (v3 != v5)
    var v13: Boolean = false
    v13 = (v6 != v7)
    var v14: Boolean = false
    v14 = (v6 != v8)
    var v15: Boolean = false
    v15 = (v9 && v11)
    var v16: Boolean = false
    v16 = (v15 && v13)
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
