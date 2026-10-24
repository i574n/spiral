fun spiral_main(): Int {
    val v0: Int = 7
    val v1: Int = -2
    val v2: Int = -7
    val v3: UInt = 100u
    val v4: UInt = 7u
    val v5: Int = (v0 / v1)
    val v6: Int = (v0 % v1)
    val v7: Int = (v2 / v1)
    val v8: Int = (v2 % v1)
    val v9: UInt = (v3 / v4)
    val v10: UInt = (v3 % v4)
    val v11: Boolean = (v5 == -3)
    var v13: Boolean = false
    if (v11) {
        val v12: Boolean = (v6 == 1)
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Boolean = false
    if (v13) {
        val v14: Boolean = (v7 == 3)
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Boolean = false
    if (v15) {
        val v16: Boolean = (v8 == -1)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        val v18: Boolean = (v9 == 14u)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        val v20: Boolean = (v10 == 2u)
        v21 = v20
    } else {
        v21 = false
    }
    if (v21) {
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
