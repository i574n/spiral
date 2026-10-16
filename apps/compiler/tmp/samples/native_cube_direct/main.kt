fun sp_method2(): Int {
    return 14
}
fun sp_method1(): Int {
    var v0: Int = 0
    v0 = sp_method2()
    var v1: Int = 0
    v1 = (14 + v0)
    return v1
}
fun sp_method0(): Int {
    var v0: Int = 0
    v0 = sp_method1()
    var v1: Int = 0
    v1 = (14 + v0)
    return v1
}
fun spiral_main(): Int {
    return sp_method0()
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
