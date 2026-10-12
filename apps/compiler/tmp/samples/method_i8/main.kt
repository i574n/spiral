fun sp_method0(p0: Byte): Byte {
    var v0: Byte = p0
    var v1: Boolean = false
    v1 = (v0 == (0).toByte())
    if (v1) {
        return (1).toByte()
    } else {
        return v0
    }
}
fun spiral_main(): Int {
    var v0: Byte = (0).toByte()
    v0 = (100).toByte()
    var v1: Byte = (0).toByte()
    v1 = sp_method0(v0)
    var v2: Boolean = false
    v2 = (v1 == (100).toByte())
    if (v2) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
