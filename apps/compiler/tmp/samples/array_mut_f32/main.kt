class Mut0(var l0: Float, var l1: String)
fun spiral_main(): Int {
    var v0: Float = 0.0f
    v0 = 1.5f
    var v1: String = ""
    v1 = "no"
    var v2: Mut0 = Mut0(0.0f, "")
    v2 = Mut0(v0, v1)
    var v3: Array<Mut0> = emptyArray<Mut0>()
    v3 = Array(1) { Mut0(0.0f, "") }
    v3[0] = v2
    var v4: Mut0 = Mut0(0.0f, "")
    v4 = v3[0]
    var v5: Float = 0.0f
    v5 = 2.5f
    var v6: String = ""
    v6 = "hi"
    v4.l0 = v5
    v4.l1 = v6
    var v7: Float = 0.0f
    var v8: String = ""
    v7 = v4.l0
    v8 = v4.l1
    var v9: Boolean = false
    v9 = (v7 == 2.5f)
    var v11: Boolean = false
    if (v9) {
        var v10: Boolean = false
        v10 = (v8 == "hi")
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
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
