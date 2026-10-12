fun closure1(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = (v0 * 10)
        var v3: Int = 0
        v3 = (v2 + v1)
        return v3
    }
    return { p0: Int -> body(p0) }
}
fun f_c0(): (Int) -> (Int) -> Int {
    fun body(v0: Int): (Int) -> Int {
        return closure1(v0)
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: (Int) -> (Int) -> Int = { _: Int -> throw RuntimeException() }
    v0 = f_c0()
    var v1: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v1 = v0(3)
    var v2: Int = 0
    v2 = v1(4)
    var v3: Boolean = false
    v3 = (v2 == 34)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
