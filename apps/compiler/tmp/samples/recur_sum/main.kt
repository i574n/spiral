fun sp_sum_0(p0: Int): Int {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 < 1)
    if (v1) {
        return 0
    } else {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v3: Int = 0
        v3 = sp_sum_0(v2)
        var v4: Int = 0
        v4 = (v0 + v3)
        return v4
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 4
    var v1: Int = 0
    v1 = sp_sum_0(v0)
    var v2: Boolean = false
    v2 = (v1 == 10)
    if (v2) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
