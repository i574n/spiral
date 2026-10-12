fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 6
    var v1: Int = 0
    v1 = 7
    var v2: Int = 0
    v2 = (v0 * v1)
    var v3: Boolean = false
    v3 = (v2 == 42)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
