class Mut0(var l0: Int)
fun f_c0(v0: Mut0): (Int) -> Mut0 {
    fun body(v1: Int): Mut0 {
        return v0
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    val v0: Mut0 = Mut0(1)
    val v1: (Int) -> Mut0 = f_c0(v0)
    var v2: Mut0 = Mut0(0)
    v2 = v1(1)
    v2.l0 = 7
    val v3: Int = v2.l0
    val v4: Boolean = (v3 == 7)
    if (v4) {
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
