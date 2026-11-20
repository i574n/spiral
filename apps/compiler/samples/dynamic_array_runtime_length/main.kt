fun sp_method0(p0: Int): Int {
    var v0: Int = p0
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 2
    v1[1] = 3
    v1[2] = 5
    v1[3] = 7
    val v2: Int = 2
    val v3: Int = v1[v2]
    val v4: Int = v1.size
    val v5: Int = (v3 + v4)
    val v6: Int = (v5 - 9)
    return v6
}
fun spiral_main(): Int {
    val v0: Int = 4
    return sp_method0(v0)
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
