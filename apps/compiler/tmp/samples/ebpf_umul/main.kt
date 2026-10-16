fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 65536u
    var v1: UInt = 0u
    v1 = 65536u
    var v2: UInt = 0u
    v2 = 4294967295u
    var v3: UInt = 0u
    v3 = 3u
    var v4: UInt = 0u
    v4 = (v0 * v1)
    var v5: UInt = 0u
    v5 = (v2 * v3)
    var v6: Boolean = false
    v6 = (v4 == 0u)
    var v8: Boolean = false
    if (v6) {
        var v7: Boolean = false
        v7 = (v5 == 4294967293u)
        v8 = v7
    } else {
        v8 = false
    }
    if (v8) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
