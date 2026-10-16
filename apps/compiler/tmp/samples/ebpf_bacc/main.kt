fun sp_method1(p0: Int, p1: Boolean): Boolean {
    var v0: Int = p0
    var v1: Boolean = p1
    while (true) {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v4: Boolean = false
        if (v1) {
            var v3: Boolean = false
            v3 = (v0 > 0)
            v4 = v3
        } else {
            v4 = false
        }
        var v5: Boolean = false
        v5 = (v2 == 0)
        if (v5) {
            return v4
        } else {
            val t472_2: Int = v2
            val t506_4: Boolean = v4
            v0 = t472_2
            v1 = t506_4
            continue
        }
    }
    return false
}
fun sp_method0(p0: Int): Boolean {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = true
    var v2: Boolean = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
fun sp_method2(p0: Int): Boolean {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = false
    var v2: Boolean = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Boolean = false
    v1 = sp_method0(v0)
    var v2: Boolean = false
    v2 = sp_method2(v0)
    if (v1) {
        if (v2) {
            return 1
        } else {
            return 0
        }
    } else {
        return 2
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
