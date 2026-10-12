fun sp_method1(p0: Int): Int {
    var v0: Int = p0
    while (true) {
        var v1: Int = 0
        v1 = (v0 - 1)
        var v2: Boolean = false
        v2 = (v1 == 0)
        if (v2) {
            return 0
        } else {
            val t238_1: Int = v1
            v0 = t238_1
            continue
        }
    }
    return 0
}
fun sp_method0(p0: Int): Int {
    var v0: Int = p0
    var v1: Boolean = false
    v1 = (v0 == 0)
    if (v1) {
        return 0
    } else {
        return sp_method1(v0)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1000000
    return sp_method0(v0)
}
fun main() {
    System.exit(spiral_main())
}
