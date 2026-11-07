class Mut0(var l0: Float, var l1: String)
fun spiral_main(): Int {
    val v0: Float = 1.5f
    val v1: String = "no"
    var v2: Mut0 = Mut0(0.0f, "")
    v2 = Mut0(v0, v1)
    val v3: Float = 2.5f
    val v4: String = "hi"
    v2.l0 = v3
    v2.l1 = v4
    var v5: Float = 0.0f
    var v6: String = ""
    v5 = v2.l0
    v6 = v2.l1
    val v7: Boolean = (v5 == 2.5f)
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
