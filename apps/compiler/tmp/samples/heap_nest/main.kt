class Heap0(val l0: Int)
class Heap1(val l0: Heap0)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Heap0 = Heap0(0)
    v1 = Heap0(v0)
    var v2: Heap1 = Heap1(Heap0(0))
    v2 = Heap1(v1)
    var v3: Heap0 = Heap0(0)
    v3 = v2.l0
    var v4: Int = 0
    v4 = v3.l0
    var v5: Boolean = false
    v5 = (v4 == 7)
    if (v5) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
