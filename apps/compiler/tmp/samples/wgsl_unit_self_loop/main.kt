fun sp_fill_0(p0: Int, p1: Array<Int>, p2: Int) {
    var v0: Int = p0
    var v1: Array<Int> = p1
    var v2: Int = p2
    while (true) {
        var v3: Boolean = false
        v3 = (v2 < v0)
        if (v3) {
            v1[v2] = v2
            var v4: Int = 0
            v4 = (v2 + 1)
            val t301_0: Int = v0
            val t335_1: Array<Int> = v1
            val t376_4: Int = v4
            v0 = t301_0
            v1 = t335_1
            v2 = t376_4
            continue
        } else {
            return
        }
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 6
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(6) { 0 }
    var v2: Int = 0
    v2 = 0
    sp_fill_0(v0, v1, v2)
    var v3: Int = 0
    v3 = v1[5]
    var v4: Int = 0
    v4 = (v3 + 2)
    return v4
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
