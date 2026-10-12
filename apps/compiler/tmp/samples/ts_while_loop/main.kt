fun sp_method0(p0: Int): Boolean {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 < 10)
    return v1
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 0
    var v1: Int = 0
    v1 = 0
    while (true) {
        if (!(sp_method0(v0))) break
        var v3: Int = 0
        v3 = (v1 + v0)
        v1 = v3
        var v4: Int = 0
        v4 = (v0 + 1)
        v0 = v4
    }
    var v5: Int = 0
    v5 = (v1 - 45)
    return v5
}
fun main() {
    System.exit(spiral_main())
}
