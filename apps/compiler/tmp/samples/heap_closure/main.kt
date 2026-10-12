class Heap0(val l0: (Int) -> Int)
fun f_c0(v0: Int): (Int) -> Int {
    fun body(v1: Int): Int {
        var v2: Int = 0
        v2 = (v1 + v0)
        return v2
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: Heap0 = Heap0({ _: Int -> throw RuntimeException() })
    v2 = Heap0(v1)
    var v3: (Int) -> Int = { _: Int -> throw RuntimeException() }
    v3 = v2.l0
    var v4: Int = 0
    v4 = v3(4)
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
