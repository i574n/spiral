class Heap0(val l0: Array<String>, val l1: Boolean)
fun spiral_main(): Int {
    var v0: Array<String> = emptyArray<String>()
    v0 = Array(1) { "" }
    val v1: String = "hi"
    v0[0] = v1
    val v2: Boolean = true
    val v3: Heap0 = Heap0(v0, v2)
    var v4: Array<String> = emptyArray<String>()
    var v5: Boolean = false
    v4 = v3.l0
    v5 = v3.l1
    val v6: String = v4[0]
    val v7: Boolean = (v6 == "hi")
    val v8: Boolean = (v7 && v5)
    if (v8) {
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
