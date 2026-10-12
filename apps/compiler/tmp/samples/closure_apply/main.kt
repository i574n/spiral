fun f_c0(): (Int) -> Int {
    fun body(v0: Int): Int {
        var v1: Int = 0
        v1 = (v0 + 1)
        return v1
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v0 = f_c0()
    var v1: Int = 0
    v1 = v0(6)
    var v2: Boolean = false
    v2 = (v1 == 7)
    if (v2) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
