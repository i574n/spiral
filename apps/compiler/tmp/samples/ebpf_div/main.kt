fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Int = 0
    v1 = -2
    var v2: Int = 0
    v2 = -7
    var v3: UInt = 0u
    v3 = 100u
    var v4: UInt = 0u
    v4 = 7u
    var v5: Int = 0
    v5 = (v0 / v1)
    var v6: Int = 0
    v6 = (v0 % v1)
    var v7: Int = 0
    v7 = (v2 / v1)
    var v8: Int = 0
    v8 = (v2 % v1)
    var v9: UInt = 0u
    v9 = (v3 / v4)
    var v10: UInt = 0u
    v10 = (v3 % v4)
    var v11: Boolean = false
    v11 = (v5 == -3)
    var v13: Boolean = false
    if (v11) {
        var v12: Boolean = false
        v12 = (v6 == 1)
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Boolean = false
    if (v13) {
        var v14: Boolean = false
        v14 = (v7 == 3)
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Boolean = false
    if (v15) {
        var v16: Boolean = false
        v16 = (v8 == -1)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Boolean = false
    if (v17) {
        var v18: Boolean = false
        v18 = (v9 == 14u)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Boolean = false
    if (v19) {
        var v20: Boolean = false
        v20 = (v10 == 2u)
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
