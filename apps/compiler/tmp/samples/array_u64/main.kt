fun spiral_main(): Int {
    var v0: Array<ULong> = emptyArray<ULong>()
    v0 = Array(1) { 0uL }
    var v1: ULong = 0uL
    v1 = 4294967297uL
    v0[0] = v1
    var v2: ULong = 0uL
    v2 = v0[0]
    var v3: Boolean = false
    v3 = (v2 == 4294967297uL)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
