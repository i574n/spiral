class Mut0(var l0: Int)
fun sp_method0(p0: Mut0): Mut0 {
    var v0: Mut0 = p0
    return v0
}
fun spiral_main(): Int {
    var v0: Mut0 = Mut0(0)
    v0 = Mut0(1)
    var v1: Mut0 = Mut0(0)
    v1 = sp_method0(v0)
    v1.l0 = 7
    var v2: Int = 0
    v2 = v1.l0
    var v3: Boolean = false
    v3 = (v2 == 7)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
