fun sp_method0(p0: UInt): Boolean {
    var v0: UInt = p0
    var v1: UInt = 0u
    v1 = (v0 + 5u)
    var v2: UInt = 0u
    v2 = (v1 % 4u)
    var v3: Boolean = false
    v3 = (v2 == 0u)
    return v3
}
fun spiral_main(): Int {
    var v0: UInt = 0u
    v0 = 7u
    var v1: Boolean = false
    v1 = sp_method0(v0)
    if (v1) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
