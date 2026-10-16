fun sp_f_0(p0: Int): Int {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 1)
    if (v1) {
        return 0
    } else {
        return 1
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    return sp_f_0(v0)
}
fun main() {
    System.exit(spiral_main())
}
