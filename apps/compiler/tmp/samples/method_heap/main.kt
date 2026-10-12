class Heap0(val l0: Int)
fun sp_method0(p0: Heap0): Heap0 {
    var v0: Heap0 = p0
    return v0
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Heap0 = Heap0(0)
    v1 = Heap0(v0)
    var v2: Heap0 = Heap0(0)
    v2 = sp_method0(v1)
    var v3: Int = 0
    v3 = v2.l0
    var v4: Boolean = false
    v4 = (v3 == 7)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
