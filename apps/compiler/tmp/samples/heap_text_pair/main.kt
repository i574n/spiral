class Heap0(val l0: String, val l1: String)
fun spiral_main(): Int {
    var v0: String = ""
    v0 = "hi"
    var v1: String = ""
    v1 = "yo"
    var v2: Heap0 = Heap0("", "")
    v2 = Heap0(v0, v1)
    var v3: String = ""
    var v4: String = ""
    v3 = v2.l0
    v4 = v2.l1
    var v5: Boolean = false
    v5 = (v3 == "hi")
    var v7: Boolean = false
    if (v5) {
        var v6: Boolean = false
        v6 = (v4 == "yo")
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
