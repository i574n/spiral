fun sp_method1(p0: Int, p1: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    while (true) {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v3: Int = 0
        v3 = (v1 + 3)
        var v4: Boolean = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            v0 = v2
            v1 = v3
            continue
        }
    }
    return 0
}
fun sp_method0(p0: Int): Int {
    var v0: Int = p0
    var v1: Int = 0
    v1 = 0
    var v2: Boolean = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
fun sp_method3(p0: Int, p1: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    while (true) {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v3: Int = 0
        v3 = (v1 - 2)
        var v4: Boolean = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            v0 = v2
            v1 = v3
            continue
        }
    }
    return 0
}
fun sp_method2(p0: Int): Int {
    var v0: Int = p0
    var v1: Int = 0
    v1 = 0
    var v2: Boolean = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method3(v0, v1)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 4
    var v1: Int = 0
    v1 = sp_method0(v0)
    var v2: Int = 0
    v2 = sp_method2(v0)
    var v3: Boolean = false
    v3 = (v1 == 12)
    var v5: Boolean = false
    if (v3) {
        var v4: Boolean = false
        v4 = (v2 == -8)
        v5 = v4
    } else {
        v5 = false
    }
    if (v5) {
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
