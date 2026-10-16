fun sp_method1(p0: Int, p1: UInt): UInt {
    var v0: Int = p0
    var v1: UInt = p1
    while (true) {
        var v2: Int = 0
        v2 = (v0 - 1)
        var v3: UInt = 0u
        v3 = (v1 + 3000000000u)
        var v4: Boolean = false
        v4 = (v2 == 0)
        if (v4) {
            return v3
        } else {
            val t333_2: Int = v2
            val t367_3: UInt = v3
            v0 = t333_2
            v1 = t367_3
            continue
        }
    }
    return 0u
}
fun sp_method0(p0: Int, p1: UInt): UInt {
    var v0: Int = p0
    var v1: UInt = p1
    var v2: Boolean = false
    v2 = (v0 == 0)
    if (v2) {
        return v1
    } else {
        return sp_method1(v0, v1)
    }
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: UInt = 0u
    v1 = 0u
    var v2: UInt = 0u
    v2 = sp_method0(v0, v1)
    var v3: Boolean = false
    v3 = (v2 == 1705032704u)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
