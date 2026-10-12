fun spiral_main(): Int {
    var v0: Array<Byte> = emptyArray<Byte>()
    v0 = Array(1) { (0).toByte() }
    var v1: Byte = (0).toByte()
    v1 = (100).toByte()
    v0[0] = v1
    var v2: Byte = (0).toByte()
    v2 = v0[0]
    var v3: Boolean = false
    v3 = (v2 == (100).toByte())
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
