fun spiral_main(): Int {
    var v0: Array<Long> = emptyArray<Long>()
    v0 = Array(2) { 0L }
    var v1: Long = 0L
    v1 = 5000000000L
    v0[1] = v1
    var v2: Long = 0L
    v2 = v0[1]
    var v3: Boolean = false
    v3 = (v2 == 5000000000L)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
