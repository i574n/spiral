class Mut0(var l0: String)
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "no"
    var v1: Mut0 = Mut0("")
    v1 = Mut0(v0)
    var v2: String = ""
    v2 = "hi"
    v1.l0 = v2
    var v3: String = ""
    v3 = v1.l0
    var v4: Boolean = false
    v4 = (v3 == "hi")
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
