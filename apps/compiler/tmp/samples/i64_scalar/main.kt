fun spiral_main(): Int {
    var v0: Long = 0L
    v0 = 5000000000L
    var v1: Long = 0L
    v1 = -4L
    var v2: Long = 0L
    v2 = (v0 / v1)
    var v3: Long = 0L
    v3 = 1000000L
    var v4: Long = 0L
    v4 = (v3 * v3)
    var v5: Long = 0L
    v5 = -8L
    var v6: Long = 0L
    v6 = (v5 shr 1)
    var v7: Int = 0
    v7 = 7
    var v8: Long = 0L
    v8 = (v7).toLong()
    var v9: Long = 0L
    v9 = 9L
    var v10: Int = 0
    v10 = (v9).toInt()
    var v11: ULong = 0uL
    v11 = 4294967296uL
    var v12: ULong = 0uL
    v12 = (v11 + 1uL)
    var v13: ULong = 0uL
    v13 = (v11 shr 1)
    var v14: ULong = 0uL
    v14 = (v7).toULong()
    var v15: Boolean = false
    v15 = (v2 == -1250000000L)
    var v17: Boolean = false
    if (v15) {
        var v16: Boolean = false
        v16 = (v4 == 1000000000000L)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        var v18: Boolean = false
        v18 = (v6 == -4L)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        var v20: Boolean = false
        v20 = (v8 == 7L)
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Boolean = false
    if (v21) {
        var v22: Boolean = false
        v22 = (v10 == 9)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Boolean = false
    if (v23) {
        var v24: Boolean = false
        v24 = (v12 == 4294967297uL)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Boolean = false
    if (v25) {
        var v26: Boolean = false
        v26 = (v13 == 2147483648uL)
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Boolean = false
    if (v27) {
        var v28: Boolean = false
        v28 = (v14 == 7uL)
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
