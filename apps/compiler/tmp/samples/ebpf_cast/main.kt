fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = -2
    var v2: UInt = 0u
    v2 = 7u
    var v3: Float = 0.0f
    v3 = 2.9f
    var v4: Float = 0.0f
    v4 = (v0).toFloat()
    var v5: Float = 0.0f
    v5 = (v1).toFloat()
    var v6: Float = 0.0f
    v6 = (v2).toFloat()
    var v7: UInt = 0u
    v7 = (v3).toUInt()
    var v8: Boolean = false
    v8 = (v4 == 3.0f)
    var v10: Boolean = false
    if (v8) {
        var v9: Boolean = false
        v9 = (v5 == -2.0f)
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Boolean = false
    if (v10) {
        var v11: Boolean = false
        v11 = (v6 == 7.0f)
        v12 = v11
    } else {
        v12 = false
    }
    var v14: Boolean = false
    if (v12) {
        var v13: Boolean = false
        v13 = (v7 == 2u)
        v14 = v13
    } else {
        v14 = false
    }
    if (v14) {
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
