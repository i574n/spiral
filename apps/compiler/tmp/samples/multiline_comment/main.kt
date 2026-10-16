fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 7
    var v1: Int = 0
    v1 = (v0 * 2)
    var v2: Boolean = false
    v2 = (v1 == 14)
    var v3: Boolean = false
    v3 = (v2 != true)
    if (v3) {
        return 1
    } else {
        return 0
    }
}
fun main() {
    System.exit(spiral_main())
}
