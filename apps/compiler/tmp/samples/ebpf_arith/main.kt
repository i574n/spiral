fun spiral_main(): Int {
    val v0: Int = 7
    val v1: Int = 2
    val v2: UInt = 4294967295u
    val v3: Int = (-(v0))
    val v4: Int = -3
    val v5: Int = -12
    val v6: Int = -4
    val v7: Int = -1
    val v8: Int = (v3 / v1)
    val v9: Boolean = (v8 == v4)
    if (v9) {
        val v10: Int = (v3 % v1)
        val v11: Boolean = (v10 == v7)
        if (v11) {
            val v12: Int = (v3 shr 1)
            val v13: Boolean = (v12 == v6)
            if (v13) {
                val v14: Int = (v4 shl 2)
                val v15: Boolean = (v14 == v5)
                if (v15) {
                    val v16: UInt = (v2 + 1u)
                    val v17: Boolean = (v16 == 0u)
                    if (v17) {
                        val v18: UInt = (v2 * v2)
                        val v19: Boolean = (v18 == 1u)
                        if (v19) {
                            val v20: UInt = (v2 shr 28)
                            val v21: Boolean = (v20 == 15u)
                            if (v21) {
                                return 0
                            } else {
                                return 7
                            }
                        } else {
                            return 6
                        }
                    } else {
                        return 5
                    }
                } else {
                    return 4
                }
            } else {
                return 3
            }
        } else {
            return 2
        }
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
