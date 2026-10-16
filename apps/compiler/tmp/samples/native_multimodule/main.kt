fun sp_method0(p0: Int, p1: Int, p2: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = 0
    v3 = (v0 * v1)
    var v4: Int = 0
    v4 = (v3 + v2)
    var v5: Int = 0
    v5 = (v4 - 42)
    return v5
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 5
    var v1: Int = 0
    v1 = 8
    var v2: Int = 0
    v2 = 2
    return sp_method0(v0, v1, v2)
}
fun main() {
    System.exit(spiral_main())
}
