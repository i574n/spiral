class Mut0(var l0: Int, var l1: String)
class Heap1(val l0: Mut0)
fun spiral_main(): Int {
    val v0: Int = 3
    val v1: String = "no"
    val v2: Mut0 = Mut0(v0, v1)
    val v3: Heap1 = Heap1(v2)
    var v4: Mut0 = Mut0(0, "")
    v4 = v3.l0
    val v5: Int = 7
    val v6: String = "hi"
    v4.l0 = v5
    v4.l1 = v6
    var v7: Int = 0
    var v8: String = ""
    v7 = v4.l0
    v8 = v4.l1
    val v9: Boolean = (v7 == 7)
    var v11: Boolean = false
    if (v9) {
        val v10: Boolean = (v8 == "hi")
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
