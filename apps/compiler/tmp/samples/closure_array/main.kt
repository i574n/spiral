fun f_c0(v0: Int): (Int) -> Array<Int> {
    fun body(v1: Int): Array<Int> {
        var v2: Array<Int> = emptyArray<Int>()
        v2 = Array(1) { 0 }
        v2[0] = v0
        return v2
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: (Int) -> Array<Int> = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: Array<Int> = emptyArray<Int>()
    v2 = v1(1)
    var v3: Int = 0
    v3 = v2[0]
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
