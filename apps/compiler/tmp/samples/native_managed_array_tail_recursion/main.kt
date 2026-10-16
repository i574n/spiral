fun sp_method1(p0: Int, p1: Array<Int>, p2: Array<Int>): Array<Int> {
    var v0: Int = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    while (true) {
        var v3: Int = 0
        v3 = (v0 - 1)
        var v4: Boolean = false
        v4 = (v3 == 0)
        if (v4) {
            return v2
        } else {
            val t336_3: Int = v3
            val t370_2: Array<Int> = v2
            val t411_1: Array<Int> = v1
            v0 = t336_3
            v1 = t370_2
            v2 = t411_1
            continue
        }
    }
    return emptyArray<Int>()
}
fun sp_method0(p0: Array<Int>, p1: Array<Int>): Array<Int> {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Int = 0
    v2 = 1000000
    var v3: Boolean = false
    v3 = (v2 == 0)
    if (v3) {
        return v0
    } else {
        return sp_method1(v2, v0, v1)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    var v2: Array<Int> = emptyArray<Int>()
    v2 = Array(v0) { 0 }
    v1[0] = 7
    v2[0] = 11
    var v3: Array<Int> = emptyArray<Int>()
    v3 = sp_method0(v1, v2)
    v3[0] = 13
    var v4: Int = 0
    v4 = v1[0]
    var v5: Boolean = false
    v5 = (v4 == 13)
    if (v5) {
        var v6: Int = 0
        v6 = v2[0]
        var v7: Boolean = false
        v7 = (v6 == 11)
        if (v7) {
            return 0
        } else {
            return 2
        }
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
