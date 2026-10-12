class Heap0(val l0: Int, val l1: Int)
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Int = 0
    v1 = 4
    var v2: Heap0 = Heap0(0, 0)
    v2 = Heap0(v0, v1)
    var v3: Int = 0
    var v4: Int = 0
    v3 = v2.l0
    v4 = v2.l1
    var v5: Int = 0
    v5 = (v3 + v4)
    var v6: Boolean = false
    v6 = (v5 == 7)
    if (v6) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
