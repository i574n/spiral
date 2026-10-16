class Heap0(val l0: Int, val l1: String, val l2: Boolean)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Boolean = false
    v2 = true
    var v3: Heap0 = Heap0(0, "", false)
    v3 = Heap0(v0, v1, v2)
    var v4: Int = 0
    var v5: String = ""
    var v6: Boolean = false
    v4 = v3.l0
    v5 = v3.l1
    v6 = v3.l2
    var v7: Boolean = false
    v7 = (v4 == 7)
    var v9: Boolean = false
    if (v7) {
        var v8: Boolean = false
        v8 = (v5 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    var v10: Boolean = false
    v10 = (v9 && v6)
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
