fun spiral_main(): Int {
    var v0: Array<String> = emptyArray<String>()
    v0 = Array(2) { "" }
    var v1: String = ""
    v1 = "hi"
    v0[1] = v1
    var v2: String = ""
    v2 = v0[1]
    var v3: Boolean = false
    v3 = (v2 == "hi")
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
