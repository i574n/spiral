class Heap0(val l0: Boolean, val l1: String)
fun spiral_main(): Int {
    var v0: Boolean = false
    v0 = true
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(false, "")
    v2 = Heap0(v0, v1)
    var v3: Boolean = false
    var v4: String = ""
    v3 = v2.l0
    v4 = v2.l1
    var v6: Boolean = false
    if (v3) {
        var v5: Boolean = false
        v5 = (v4 == "hi")
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
