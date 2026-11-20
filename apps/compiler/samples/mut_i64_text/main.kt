class Mut0(var l0: Long, var l1: String)
fun spiral_main(): Int {
    val v0: Long = 3L
    val v1: String = "no"
    var v2: Mut0 = Mut0(0L, "")
    v2 = Mut0(v0, v1)
    val v3: Long = 5000000000L
    val v4: String = "hi"
    v2.l0 = v3
    v2.l1 = v4
    var v5: Long = 0L
    var v6: String = ""
    v5 = v2.l0
    v6 = v2.l1
    val v7: Boolean = (v5 == 5000000000L)
    var v9: Boolean = false
    if (v7) {
        val v8: Boolean = (v6 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
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
