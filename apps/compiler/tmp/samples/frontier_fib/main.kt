fun sp_fib_0(p0: Int): Int {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 <= 1)
    if (v1) {
        return v0
    } else {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v3: Int = 0
        v3 = sp_fib_0(v2)
        var v4: Int = 0
        v4 = (v0 - 2)
        var v5: Int = 0
        v5 = sp_fib_0(v4)
        var v6: Int = 0
        v6 = (v3 + v5)
        return v6
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 10
    var v1: Int = 0
    v1 = sp_fib_0(v0)
    var v2: Int = 0
    v2 = (v1 - 55)
    return v2
}
fun main() {
    System.exit(spiral_main())
}
