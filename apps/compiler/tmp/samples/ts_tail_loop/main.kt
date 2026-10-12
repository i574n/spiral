fun sp_method1(p0: Int, p1: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    while (true) {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v3: Int = 0
        v3 = (v1 + v0)
        var v4: Boolean = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            val t319_2: Int = v2
            val t353_3: Int = v3
            v0 = t319_2
            v1 = t353_3
            continue
        }
    }
    return 0
}
fun sp_method0(p0: Int): Int {
    var v0: Int = p0
    var v1: Int = 0
    v1 = 0
    var v2: Boolean = false
    v2 = (v0 == 0)
    var v4: Int = 0
    if (v2) {
        v4 = v1
    } else {
        v4 = sp_method1(v0, v1)
    }
    var v5: Int = 0
    v5 = (v4 - 55)
    return v5
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 10
    return sp_method0(v0)
}
fun main() {
    System.exit(spiral_main())
}
