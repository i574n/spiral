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
            val v7: Int = v1[v6]
            val v8: Int = (v3 + 1)
            val v9: Int = (v4 * 7)
            val v10: Int = (v9 + v7)
            val v11: Int = (v10 + v2)
            val v12: Int = (v11 % 9973)
            v3 = v8
            v4 = v12
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
    val v1: Int = 0
    val v2: Int = 1000000
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
