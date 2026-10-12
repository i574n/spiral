fun spiral_main(): Int {
    var v0: Array<Boolean> = emptyArray<Boolean>()
    v0 = Array(1) { false }
    var v1: Boolean = false
    v1 = true
    v0[0] = v1
    var v2: Boolean = false
    v2 = v0[0]
    if (v2) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
