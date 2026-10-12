fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Array<UInt> = emptyArray<UInt>()
    v1 = Array(v0) { 0u }
    v1[0] = 4000000000u
    v1[1] = 1u
    var v2: UInt = 0u
    v2 = v1[0]
    var v3: UInt = 0u
    v3 = v1[1]
    var v4: UInt = 0u
    v4 = (v2 + v3)
    var v5: Int = 0
    v5 = v1.size
    var v6: Boolean = false
    v6 = (v5 == v0)
    var v8: Boolean = false
    if (v6) {
        var v7: Boolean = false
        v7 = (v4 == 4000000001u)
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
