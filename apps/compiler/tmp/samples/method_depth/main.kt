fun h_c1(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Boolean = false
        v2 = (v0 == 0)
        if (v2) {
            return 0
        } else {
            var v3: Int = 0
            v3 = (v1 + v0)
            return v3
        }
    }
    return { p0: Int -> body(p0) }
}
fun g_c0(v0: Int): (Int) -> (Int) -> Int {
    fun body(v1: Int): (Int) -> Int {
        return h_c1(v0)
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: Int): (Int) -> (Int) -> Int {
    var v0: Int = p0
    return g_c0(v0)
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: (Int) -> (Int) -> Int = { _: Int -> throw RuntimeException() }
    v1 = sp_method0(v0)
    var v2: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v2 = v1(0)
    var v3: Int = 0
    v3 = v2(0)
    var v4: Boolean = false
    v4 = (v3 == 7)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
