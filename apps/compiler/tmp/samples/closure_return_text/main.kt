fun g_c1(v0: String, v1: Int): (Int) -> String {
    fun body(v2: Int): String {
        var v3: Boolean = false
        v3 = (v1 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            return v4
        } else {
            return v0
        }
    }
    return { p0: Int -> body(p0) }
}
fun f_c0(v0: String): (Int) -> (Int) -> String {
    fun body(v1: Int): (Int) -> String {
        return g_c1(v0, v1)
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "hi"
    var v1: (Int) -> (Int) -> String = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: (Int) -> String = { _: Int -> throw RuntimeException() }
    v2 = v1(1)
    var v3: String = ""
    v3 = v2(0)
    var v4: Boolean = false
    v4 = (v3 == "hi")
    if (v4) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
