class Mut0(var l0: Int)
fun sp_method0(p0: Mut0) {
    var v0: Mut0 = p0
    var v1: Int = 0
    v1 = v0.l0
    var v2: Int = 0
    v2 = (v1 + 5)
    v0.l0 = v2
}
fun sp_method1(p0: Mut0) {
    var v0: Mut0 = p0
}
fun sp_method2(p0: Mut0) {
    var v0: Mut0 = p0
    var v1: Int = 0
    v1 = v0.l0
    var v2: Int = 0
    v2 = (v1 + 7)
    v0.l0 = v2
}
fun spiral_main(): Int {
    var v0: Mut0 = Mut0(0)
    v0 = Mut0(0)
    sp_method0(v0)
    sp_method1(v0)
    sp_method2(v0)
    var v1: Int = 0
    v1 = v0.l0
    var v2: Int = 0
    v2 = (v1 - 12)
    return v2
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
