class Mut0(var l0: String)
fun spiral_main(): Int {
    val v0: String = "no"
    var v1: Mut0 = Mut0("")
    v1 = Mut0(v0)
    val v2: String = "hi"
    v1.l0 = v2
    val v3: String = v1.l0
    val v4: Boolean = (v3 == "hi")
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
