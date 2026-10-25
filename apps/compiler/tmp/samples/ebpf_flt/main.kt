fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = -2.0f
    var v1: Float = 0.0f
    v1 = -1.0f
    var v2: Float = 0.0f
    v2 = 0.0f
    var v3: Boolean = false
    v3 = (v0 < v1)
    var v5: Boolean = false
    if (v3) {
        var v4: Boolean = false
        v4 = (v1 < v2)
        v5 = v4
    } else {
        v5 = false
    }
    var v8: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v0 > v1)
        var v7: Boolean = false
        v7 = (v6 == false)
        v8 = v7
    } else {
        v8 = false
    }
    var v11: Boolean = false
    if (v8) {
        var v9: Boolean = false
        v9 = (v0 >= v1)
        var v10: Boolean = false
        v10 = (v9 == false)
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Boolean = false
    if (v11) {
        var v12: Boolean = false
        v12 = (v1 <= v2)
        v13 = v12
    } else {
        v13 = false
    }
    if (v13) {
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
