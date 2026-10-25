fun sp_method0(p0: Array<Int>) {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = 1
    var v2: Int = 0
    v2 = 9
    v0[v1] = v2
}
fun sp_method1(p0: Array<Int>): Int {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = v0[v1]
    return v2
}
fun sp_method2(p0: Array<Int>): Int {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = 1
    var v2: Int = 0
    v2 = v0[v1]
    return v2
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 1
    v1[1] = 2
    sp_method0(v1)
    var v2: Int = 0
    v2 = sp_method1(v1)
    val v3: Int = sp_method2(v1)
    val v4: Int = (v2 + v3)
    val v5: Int = (v4 - 10)
    return v5
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
