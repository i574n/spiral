class Heap0(val l0: UInt, val l1: String, val l2: Boolean)
fun spiral_main(): Int {
    val v0: UInt = 4000000000u
    val v1: String = "hi"
    val v2: Boolean = true
    val v3: Heap0 = Heap0(v0, v1, v2)
    var v4: UInt = 0u
    var v5: String = ""
    var v6: Boolean = false
    v4 = v3.l0
    v5 = v3.l1
    v6 = v3.l2
    val v7: Boolean = (v4 == 4000000000u)
    var v9: Boolean = false
    if (v7) {
        val v8: Boolean = (v5 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    val v10: Boolean = (v9 && v6)
    if (v10) {
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
