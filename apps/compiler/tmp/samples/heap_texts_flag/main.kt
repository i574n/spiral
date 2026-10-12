class Heap0(val l0: Array<String>, val l1: Boolean)
fun spiral_main(): Int {
    var v0: Array<String> = emptyArray<String>()
    v0 = Array(1) { "" }
    var v1: String = ""
    v1 = "hi"
    v0[0] = v1
    var v2: Boolean = false
    v2 = true
    var v3: Heap0 = Heap0(emptyArray<String>(), false)
    v3 = Heap0(v0, v2)
    var v4: Array<String> = emptyArray<String>()
    var v5: Boolean = false
    v4 = v3.l0
    v5 = v3.l1
    var v6: String = ""
    v6 = v4[0]
    var v7: Boolean = false
    v7 = (v6 == "hi")
    var v8: Boolean = false
    v8 = (v7 && v5)
    if (v8) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
