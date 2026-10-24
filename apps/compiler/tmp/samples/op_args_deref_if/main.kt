class Mut0(var l0: String)
fun spiral_main(): Int {
    val v0: String = "deref"
    var v1: Mut0 = Mut0("")
    v1 = Mut0(v0)
    val v2: Int = 3
    val v3: String = "deref!"
    v1.l0 = v3
    val v4: String = v1.l0
    val v5: Boolean = (v2 == 3)
    var v7: Int = 0
    if (v5) {
        val v6: Int = (v2 + 1)
        v7 = v6
    } else {
        v7 = 0
    }
    System.out.write((v4 + " " + (v7).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    val v8: Int = (v2 * 2)
    val v9: Boolean = (v2 > 0)
    var v10: Int = 0
    if (v9) {
        v10 = 6
    } else {
        v10 = 0
    }
    val v11: Boolean = (v8 == v10)
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
