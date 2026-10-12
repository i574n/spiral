class Heap0(val l0: Byte)
fun spiral_main(): Int {
    var v0: Byte = (0).toByte()
    v0 = (100).toByte()
    var v1: Heap0 = Heap0((0).toByte())
    v1 = Heap0(v0)
    var v2: Byte = (0).toByte()
    v2 = v1.l0
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
