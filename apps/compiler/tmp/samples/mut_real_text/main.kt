class Mut0(var l0: Double, var l1: String)
fun spiral_main(): Int {
    var v0: Double = 0.0
    v0 = 1.5
    var v1: String = ""
    v1 = "no"
    var v2: Mut0 = Mut0(0.0, "")
    v2 = Mut0(v0, v1)
    var v3: Double = 0.0
    v3 = 2.5
    var v4: String = ""
    v4 = "hi"
    v2.l0 = v3
    v2.l1 = v4
    var v5: Double = 0.0
    var v6: String = ""
    v5 = v2.l0
    v6 = v2.l1
    var v7: Boolean = false
    v7 = (v5 == 2.5)
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v6 == "hi")
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
