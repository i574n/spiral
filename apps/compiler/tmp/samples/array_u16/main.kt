fun spiral_main(): Int {
    var v0: Array<UShort> = emptyArray<UShort>()
    v0 = Array(1) { (0).toUShort() }
    var v1: UShort = (0).toUShort()
    v1 = (40000).toUShort()
    v0[0] = v1
    var v2: UShort = (0).toUShort()
    v2 = v0[0]
    var v3: Boolean = false
    v3 = (v2 == (40000).toUShort())
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
