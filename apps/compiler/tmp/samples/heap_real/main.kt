class Heap0(val l0: Double)
fun spiral_main(): Int {
    var v0: Double = 0.0
    v0 = 1.5
    var v1: Heap0 = Heap0(0.0)
    v1 = Heap0(v0)
    var v2: Double = 0.0
    v2 = v1.l0
    var v3: Boolean = false
    v3 = (v2 == 1.5)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
