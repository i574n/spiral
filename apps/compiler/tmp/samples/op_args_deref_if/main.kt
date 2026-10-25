class Mut0(var l0: String)
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "deref"
    var v1: Mut0 = Mut0("")
    v1 = Mut0(v0)
    var v2: Int = 0
    v2 = 3
    var v3: String = ""
    v3 = "deref!"
    v1.l0 = v3
    var v4: String = ""
    v4 = v1.l0
    var v5: Boolean = false
    v5 = (v2 == 3)
    var v7: Int = 0
    if (v5) {
        var v6: Int = 0
        v6 = (v2 + 1)
        v7 = v6
    } else {
        v7 = 0
    }
    System.out.write((v4 + " " + (v7).toString() + "\n").toByteArray(Charsets.UTF_8)); System.out.flush()
    var v8: Int = 0
    v8 = (v2 * 2)
    var v9: Boolean = false
    v9 = (v2 > 0)
    var v10: Int = 0
    if (v9) {
        v10 = 6
    } else {
        v10 = 0
    }
    var v11: Boolean = false
    v11 = (v8 == v10)
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
