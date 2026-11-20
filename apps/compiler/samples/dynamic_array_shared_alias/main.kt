fun sp_method0(p0: Array<Int>): Int {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = v0[0]
    return v1
}
fun sp_method1(p0: Array<Int>): Int {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = v0[0]
    return v1
}
fun spiral_main(): Int {
    val v0: Int = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 3
    v1[1] = 4
    val v2: Int = sp_method0(v1)
    val v3: Int = sp_method1(v1)
    val v4: Int = (v2 + v3)
    val v5: Int = (v4 - 6)
    return v5
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
