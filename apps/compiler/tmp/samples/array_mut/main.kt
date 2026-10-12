class Mut0(var l0: Int)
fun spiral_main(): Int {
    var v0: Array<Mut0> = emptyArray<Mut0>()
    v0 = Array(1) { Mut0(0) }
    var v1: Mut0 = Mut0(0)
    v1 = Mut0(1)
    v0[0] = v1
    var v2: Mut0 = Mut0(0)
    v2 = v0[0]
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
