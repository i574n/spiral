fun sp_method0(p0: Boolean): Int {
    var v0: Boolean = p0
    if (v0) {
        return 1
    } else {
        return 3
    }
}
fun sp_method1(p0: Boolean, p1: Boolean): Int {
    var v0: Boolean = p0
    var v1: Boolean = p1
    var v2: Boolean = false
    v2 = (v0 && v1)
    if (v2) {
        return 1
    } else {
        var v3: Boolean = false
        v3 = (v0 || v1)
        if (v3) {
            return 2
        } else {
            return 3
        }
    }
}
fun sp_method2(p0: Boolean): Int {
    var v0: Boolean = p0
    if (v0) {
        return 1
    } else {
        return 3
    }
}
fun spiral_main(): Int {
    val v0: Boolean = true
    val v1: Boolean = false
    var v2: Int = 0
    v2 = sp_method0(v0)
    var v3: Int = 0
    v3 = sp_method1(v0, v1)
    val v4: Int = sp_method2(v1)
    val v5: Boolean = (v0 == v1)
    val v6: Boolean = (v5 == false)
    val v7: Boolean = (v2 == 1)
    var v9: Boolean = false
    if (v7) {
        val v8: Boolean = (v3 == 2)
        v9 = v8
    } else {
        v9 = false
    }
    var v11: Boolean = false
    if (v9) {
        val v10: Boolean = (v4 == 3)
        v11 = v10
    } else {
        v11 = false
    }
    val v12: Boolean = (v11 && v6)
    if (v12) {
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
