fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 2147483647u
    var v1: UInt = 0u
    v1 = 2u
    var v2: UInt = 0u
    v2 = 1u
    var v3: UInt = 0u
    v3 = (v0 + v1)
    var v4: UInt = 0u
    v4 = (v0 + v2)
    var v5: Boolean = false
    v5 = (v3 == 2147483649u)
    var v7: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v4 == 2147483648u)
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
