fun f_c0(v0: String): (Int) -> String {
    fun body(v1: Int): String {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            var v3: String = ""
            v3 = "no"
            return v3
        } else {
            return v0
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "hi"
    var v1: (Int) -> String = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: String = ""
    v2 = v1(1)
    var v3: Boolean = false
    v3 = (v2 == "hi")
    if (v3) {
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
