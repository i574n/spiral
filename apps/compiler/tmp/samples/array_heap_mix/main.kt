class Heap0(val l0: Int, val l1: String)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(0, "")
    v2 = Heap0(v0, v1)
    var v3: Array<Heap0> = emptyArray<Heap0>()
    v3 = Array(1) { Heap0(0, "") }
    v3[0] = v2
    var v4: Heap0 = Heap0(0, "")
    v4 = v3[0]
    var v5: Int = 0
    var v6: String = ""
    v5 = v4.l0
    v6 = v4.l1
    var v7: Boolean = false
    v7 = (v5 == 7)
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
