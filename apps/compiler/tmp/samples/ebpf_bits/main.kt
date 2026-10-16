fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 4294967295u
    var v1: UInt = 0u
    v1 = 15u
    var v2: UInt = 0u
    v2 = (v0 and v1)
    var v3: UInt = 0u
    v3 = (v0 or v1)
    var v4: UInt = 0u
    v4 = (v0 xor v1)
    var v5: UInt = 0u
    v5 = (v1.inv())
    var v6: Boolean = false
    v6 = (v2 == 15u)
    var v8: Boolean = false
    if (v6) {
        var v7: Boolean = false
        v7 = (v3 == v0)
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Boolean = false
    if (v8) {
        var v9: Boolean = false
        v9 = (v4 == v5)
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Boolean = false
    if (v10) {
        var v11: Boolean = false
        v11 = (v5 == 4294967280u)
        v12 = v11
    } else {
        v12 = false
    }
    if (v12) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
