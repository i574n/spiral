class Mut0(var l0: Int, var l1: Int)
fun spiral_main(): Int {
    var v0: Mut0 = Mut0(0, 0)
    v0 = Mut0(1, 2)
    v0.l0 = 3
    v0.l1 = 4
    var v1: Int = 0
    var v2: Int = 0
    v1 = v0.l0
    v2 = v0.l1
    var v3: Int = 0
    v3 = (v1 + v2)
    return v3
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
