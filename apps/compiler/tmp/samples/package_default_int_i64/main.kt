fun spiral_main(): Int {
    var v0: Long = 0L
    v0 = 3000000000L
    var v1: Boolean = false
    v1 = (v0 > 2999999999L)
    if (v1) {
        return 7
    } else {
        return 0
    }
}
fun main() {
    System.exit(spiral_main())
}
