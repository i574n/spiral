fun spiral_main(): Int {
    val v0: Long = 5000000000L
    val v1: Long = -4L
    val v2: Long = (v0 / v1)
    val v3: Long = 1000000L
    val v4: Long = (v3 * v3)
    val v5: Long = -8L
    val v6: Long = (v5 shr 1)
    val v7: Int = 7
    val v8: Long = (v7).toLong()
    val v9: Long = 9L
    val v10: Int = (v9).toInt()
    val v11: ULong = 4294967296uL
    val v12: ULong = (v11 + 1uL)
    val v13: ULong = (v11 shr 1)
    val v14: ULong = (v7).toULong()
    val v15: Boolean = (v2 == -1250000000L)
    var v17: Boolean = false
    if (v15) {
        val v16: Boolean = (v4 == 1000000000000L)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        val v18: Boolean = (v6 == -4L)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        val v20: Boolean = (v8 == 7L)
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Boolean = false
    if (v21) {
        val v22: Boolean = (v10 == 9)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        val v24: Boolean = (v12 == 4294967297uL)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        val v26: Boolean = (v13 == 2147483648uL)
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        val v28: Boolean = (v14 == 7uL)
        v29 = v28
    } else {
        v29 = false
    }
    if (v29) {
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
