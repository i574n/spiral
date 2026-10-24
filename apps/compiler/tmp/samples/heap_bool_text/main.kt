class Heap0(val l0: Boolean, val l1: String)
fun spiral_main(): Int {
    val v0: Boolean = true
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    var v3: Boolean = false
    var v4: String = ""
    v3 = v2.l0
    v4 = v2.l1
    var v6: Boolean = false
    if (v3) {
        val v5: Boolean = (v4 == "hi")
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
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
