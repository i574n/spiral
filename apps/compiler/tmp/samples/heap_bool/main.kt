class Heap0(val l0: Boolean)
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v1: Heap0 = Heap0(false)
    v1 = Heap0(v0)
    var v2: Boolean = false
    v2 = v1.l0
    if (v2) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
