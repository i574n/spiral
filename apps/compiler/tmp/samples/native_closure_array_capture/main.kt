fun f_c0(v0: Array<Int>): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = v0.size
        var v3: Int = 0
        v3 = (v2 + v1)
        return v3
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(2) { 0 }
    var v1: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    return v1(40)
}
fun main() {
    System.exit(spiral_main())
}
