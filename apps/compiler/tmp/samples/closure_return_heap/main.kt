class Heap0(val l0: Int)
fun g_c1(v0: Heap0, v1: Int): (Int) -> Int {
    fun body(v2: Int): Int {
        var v3: Int = 0
        v3 = v0.l0
        var v4: Boolean = false
        v4 = (v1 == 0)
        if (v4) {
            return 0
        } else {
            return v3
        }
    }
    return { p0: Int -> body(p0) }
}
fun f_c0(v0: Heap0): (Int) -> (Int) -> Int {
    fun body(v1: Int): (Int) -> Int {
        return g_c1(v0, v1)
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Heap0 = Heap0(0)
    v1 = Heap0(v0)
    var v2: (Int) -> (Int) -> Int = { _: Int -> throw RuntimeException() }
    v2 = f_c0(v1)
    var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v3 = v2(1)
    var v4: Int = 0
    v4 = v3(0)
    var v5: Boolean = false
    v5 = (v4 == 7)
    if (v5) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
