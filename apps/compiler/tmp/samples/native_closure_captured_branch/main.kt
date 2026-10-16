fun a_c0(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = (v1 + v0)
        return v2
    }
    return { p0: Int -> body(p0) }
}
fun b_c1(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = (v1 + v0)
        return v2
    }
    return { p0: Int -> body(p0) }
}
fun sp_method0(p0: (Int) -> Int): Int {
    var v0: (Int) -> Int = p0
    return v0(40)
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Int = 0
    v1 = 3
    var v2: Boolean = false
    v2 = true
    var v5: (Int) -> Int = { _: Int -> throw RuntimeException() }
    if (v2) {
        v5 = a_c0(v0)
    } else {
        v5 = b_c1(v1)
    }
    return sp_method0(v5)
}
fun main() {
    System.exit(spiral_main())
}
