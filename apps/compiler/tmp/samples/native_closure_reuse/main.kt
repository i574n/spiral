fun f_c0(v0: Int, v1: Int): (Int) -> Int {
    fun body(v2: Int): Int {
        var v3: Int = 0
        v3 = (v0 + v1)
        var v4: Int = 0
        v4 = (v3 + v2)
        return v4
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Int = 0
    v1 = 2
    var v2: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v2 = f_c0(v0, v1)
    var v3: Int = 0
    v3 = v2(10)
    var v4: Int = 0
    v4 = v2(20)
    var v5: Int = 0
    v5 = v2(3)
    var v6: Int = 0
    v6 = (v3 + v4)
    var v7: Int = 0
    v7 = (v6 + v5)
    return v7
}
fun main() {
    System.exit(spiral_main())
}
