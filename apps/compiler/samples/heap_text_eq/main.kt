class Heap0(val l0: String, val l1: String)
fun spiral_main(): Int {
    val v0: String = "hi"
    val v1: Heap0 = Heap0(v0, v0)
    var v2: String = ""
    var v3: String = ""
    v2 = v1.l0
    v3 = v1.l1
    val v4: Boolean = (v2 == v3)
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
