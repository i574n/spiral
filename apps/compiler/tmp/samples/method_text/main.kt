fun sp_method0(p0: Int): String {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = "no"
        return v2
    } else {
        val v3: String = "hi"
        return v3
    }
}
fun spiral_main(): Int {
    val v0: Int = 7
    var v1: String = ""
    v1 = sp_method0(v0)
    var v2: Boolean = false
    v2 = (v1 == "hi")
    if (v2) {
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
