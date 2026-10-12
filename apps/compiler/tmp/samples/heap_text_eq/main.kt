class Heap0(val l0: String, val l1: String)
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "hi"
    var v1: Heap0 = Heap0("", "")
    v1 = Heap0(v0, v0)
    var v2: String = ""
    var v3: String = ""
    v2 = v1.l0
    v3 = v1.l1
    var v4: Boolean = false
    v4 = (v2 == v3)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
