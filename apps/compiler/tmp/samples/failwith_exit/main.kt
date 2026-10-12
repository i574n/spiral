fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 1
    var v1: Boolean = false
    v1 = (v0 == 1)
    if (v1) {
        System.err.println("bo\$om")
        System.exit(1)
        throw RuntimeException()
    } else {
        return 0
    }
}
fun main() {
    System.exit(spiral_main())
}
