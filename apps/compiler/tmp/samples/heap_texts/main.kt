class Heap0(val l0: Array<String>)
fun spiral_main(): Int {
    var v0: Array<String> = emptyArray<String>()
    v0 = Array(1) { "" }
    var v1: String = ""
    v1 = "hi"
    v0[0] = v1
    var v2: Heap0 = Heap0(emptyArray<String>())
    v2 = Heap0(v0)
    var v3: Array<String> = emptyArray<String>()
    v3 = v2.l0
    var v4: String = ""
    v4 = v3[0]
    var v5: Boolean = false
    v5 = (v4 == "hi")
    if (v5) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
