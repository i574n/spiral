fun f_c0(v0: Double): (Int) -> Double {
    fun body(v1: Int): Double {
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return 0.0
        } else {
            return v0
        }
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Double = 0.0
    v0 = 1.5
    var v1: (Int) -> Double = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: Double = 0.0
    v2 = v1(1)
    var v3: Boolean = false
    v3 = (v2 == 1.5)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
