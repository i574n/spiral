class Mut0(var l0: String)
fun sp_method2(p0: Mut0, p1: String) {
    var v0: Mut0 = p0
    var v1: String = p1
    var v2: String = ""
    v2 = v0.l0
    var v3: String = ""
    v3 = (v2 + v1)
    v0.l0 = v3
}
fun sp_format_real_1(p0: Int): String {
    var v0: Int = p0
    var v1: String = ""
    v1 = ""
    var v2: Mut0 = Mut0("")
    v2 = Mut0(v1)
    var v3: String = ""
    v3 = (v0).toString()
    sp_method2(v2, v3)
    val v4: String = v2.l0
    return v4
}
fun sp_method0(): String {
    var v0: Int = 0
    v0 = 1
    var v1: String = ""
    v1 = sp_format_real_1(v0)
    var v2: String = ""
    v2 = ("Some(" + v1)
    var v3: String = ""
    v3 = (v2 + ")")
    return v3
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = sp_method0()
    var v1: String = ""
    v1 = ("x: " + v0)
    var v2: Boolean = false
    v2 = (v1 == "")
    if (v2) {
        return 1
    } else {
        return 0
    }
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
