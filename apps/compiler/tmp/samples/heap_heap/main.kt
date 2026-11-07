class Heap0(val l0: Int, val l1: String)
class Heap1(val l0: Heap0, val l1: Int)
fun spiral_main(): Int {
    val v0: Int = 7
    val v1: String = "hi"
    val v2: Heap0 = Heap0(v0, v1)
    val v3: Int = 1
    val v4: Heap1 = Heap1(v2, v3)
    var v5: Heap0 = Heap0(0, "")
    var v6: Int = 0
    v5 = v4.l0
    v6 = v4.l1
    var v7: Int = 0
    var v8: String = ""
    v7 = v5.l0
    v8 = v5.l1
    val v9: Boolean = (v7 == 7)
    var v11: Boolean = false
    if (v9) {
        val v10: Boolean = (v8 == "hi")
        v11 = v10
    } else {
        v11 = false
    }
    var v13: Boolean = false
    if (v11) {
        val v12: Boolean = (v6 == 1)
        v13 = v12
    } else {
        v13 = false
    }
    if (v13) {
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
