fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Int = 0
    v1 = 2
    var v2: UInt = 0u
    v2 = 4294967295u
    var v3: Int = 0
    v3 = (-(v0))
    var v4: Int = 0
    v4 = -3
    var v5: Int = 0
    v5 = -12
    var v6: Int = 0
    v6 = -4
    var v7: Int = 0
    v7 = -1
    var v8: Int = 0
    v8 = (v3 / v1)
    var v9: Boolean = false
    v9 = (v8 == v4)
    if (v9) {
        var v10: Int = 0
        v10 = (v3 % v1)
        var v11: Boolean = false
        v11 = (v10 == v7)
        if (v11) {
            var v12: Int = 0
            v12 = (v3 shr 1)
            var v13: Boolean = false
            v13 = (v12 == v6)
            if (v13) {
                var v14: Int = 0
                v14 = (v4 shl 2)
                var v15: Boolean = false
                v15 = (v14 == v5)
                if (v15) {
                    var v16: UInt = 0u
                    v16 = (v2 + 1u)
                    var v17: Boolean = false
                    v17 = (v16 == 0u)
                    if (v17) {
                        var v18: UInt = 0u
                        v18 = (v2 * v2)
                        var v19: Boolean = false
                        v19 = (v18 == 1u)
                        if (v19) {
                            var v20: UInt = 0u
                            v20 = (v2 shr 28)
                            var v21: Boolean = false
                            v21 = (v20 == 15u)
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
