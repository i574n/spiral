fun sp_loop_0(p0: Int, p1: Array<Int>, p2: Int, p3: Int, p4: Int): Int {
    var v0: Int = p0
    var v1: Array<Int> = p1
    var v2: Int = p2
    var v3: Int = p3
    var v4: Int = p4
    while (true) {
        var v5: Boolean = false
        v5 = (v3 >= v0)
        if (v5) {
            return v4
        } else {
            var v6: Int = 0
            v6 = (v3 % 4)
            var v7: Int = 0
            v7 = v1[v6]
            var v8: Int = 0
            v8 = (v3 + 1)
            var v9: Int = 0
            v9 = (v4 * 7)
            var v10: Int = 0
            v10 = (v9 + v7)
            var v11: Int = 0
            v11 = (v10 + v2)
            var v12: Int = 0
            v12 = (v11 % 9973)
            val t732_0: Int = v0
            val t766_1: Array<Int> = v1
            val t807_2: Int = v2
            val t841_8: Int = v8
            val t875_12: Int = v12
            v0 = t732_0
            v1 = t766_1
            v2 = t807_2
            v3 = t841_8
            v4 = t875_12
            continue
        }
    }
    return 0
}
fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(4) { 0 }
    v0[0] = 1
    v0[1] = 2
    v0[2] = 3
    v0[3] = 4
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = 1000000
    var v3: Int = 0
    v3 = 0
    var v4: Int = 0
    v4 = 0
    var v5: Int = 0
    v5 = sp_loop_0(v2, v0, v1, v3, v4)
    var v6: Int = 0
    v6 = (v5 % 256)
    return v6
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
