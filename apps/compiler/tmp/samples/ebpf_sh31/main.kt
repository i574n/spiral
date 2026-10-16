fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 1u
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = 31
    var v3: UInt = 0u
    v3 = (v0 shl v2)
    var v4: UInt = 0u
    v4 = (v3 shr v2)
    var v5: UInt = 0u
    v5 = (v0 shl v1)
    var v6: Boolean = false
    v6 = (v3 == 2147483648u)
    var v8: Boolean = false
    if (v6) {
        var v7: Boolean = false
        v7 = (v4 == 1u)
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Boolean = false
    if (v8) {
        var v9: Boolean = false
        v9 = (v5 == 1u)
        v10 = v9
    } else {
        v10 = false
    }
    if (v10) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
