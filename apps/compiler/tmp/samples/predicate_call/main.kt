fun sp_is_answer_1(p0: Int): Boolean {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 42)
    return v1
}
fun sp_method0(p0: Int): Boolean {
    var v0: Int = p0
    return sp_is_answer_1(v0)
}
fun spiral_main(): Int {
    val v0: Int = 42
    var v1: Boolean = false
    v1 = sp_method0(v0)
    if (v1) {
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
