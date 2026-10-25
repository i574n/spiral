class Heap0(val l0: String)
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "hi"
    var v1: Heap0 = Heap0("")
    v1 = Heap0(v0)
    var v2: String = ""
    v2 = v1.l0
    var v3: Boolean = false
    v3 = (v2 == "hi")
    if (v3) {
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
