fun spiral_main(): Int {
    val v0: String = "a"
    val v1: String = "b"
    val v2: String = "é"
    val v3: String = "éx"
    val v4: String = ""
    val v5: Boolean = (v0 < v0)
    if (v5) {
        return 1
    } else {
        val v6: Boolean = (v0 < v1)
        var v8: Boolean = false
        if (v6) {
            val v7: Boolean = (v1 < v2)
            v8 = v7
        } else {
            v8 = false
        }
        var v10: Boolean = false
        if (v8) {
            val v9: Boolean = (v2 < v3)
            v10 = v9
        } else {
            v10 = false
        }
        var v12: Boolean = false
        if (v10) {
            val v11: Boolean = (v4 < v0)
            v12 = v11
        } else {
            v12 = false
        }
        var v14: Boolean = false
        if (v12) {
            val v13: Boolean = (v0 <= v0)
            v14 = v13
        } else {
            v14 = false
        }
        var v16: Boolean = false
        if (v14) {
            val v15: Boolean = (v0 >= v0)
            v16 = v15
        } else {
            v16 = false
        }
        var v18: Boolean = false
        if (v16) {
            val v17: Boolean = (v3 > v2)
            v18 = v17
        } else {
            v18 = false
        }
        var v20: Boolean = false
        if (v18) {
            val v19: Boolean = (v1 >= v0)
            v20 = v19
        } else {
            v20 = false
        }
        if (v20) {
            return 0
        } else {
            return 1
        }
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
