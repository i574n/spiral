class Mut0(var l0: Int)
fun f_c0(v0: Mut0): (Int) -> Mut0 {
    fun body(v1: Int): Mut0 {
        return v0
    }
    return { p0: Int -> body(p0) }
}
fun spiral_main(): Int {
    var v0: Mut0 = Mut0(0)
    v0 = Mut0(1)
    var v1: (Int) -> Mut0 = { _: Int -> throw RuntimeException() }
    v1 = f_c0(v0)
    var v2: Mut0 = Mut0(0)
    v2 = v1(1)
    v2.l0 = 7
    var v3: Int = 0
    v3 = v2.l0
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
