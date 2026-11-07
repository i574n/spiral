// m1
// a1
// c1
// a2
// b1
// m2
fun sp_leaf_c_1(): Int {
    return 0
}
fun sp_slow_a_0(): Int {
    var v0: Int = 0
    v0 = sp_leaf_c_1()
    return v0
}
fun sp_fast_b_2(): Int {
    return 0
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = sp_slow_a_0()
    val v1: Int = sp_fast_b_2()
    val v2: Int = (v0 + v1)
    return v2
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
