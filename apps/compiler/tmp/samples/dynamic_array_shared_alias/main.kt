fun sp_method0(p0: Array<Int>): Int {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = v0[0]
    return v1
}
fun sp_method1(p0: Array<Int>): Int {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = v0[0]
    return v1
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 3
    v1[1] = 4
    var v2: Int = 0
    v2 = sp_method0(v1)
    var v3: Int = 0
    v3 = sp_method1(v1)
    var v4: Int = 0
    v4 = (v2 + v3)
    var v5: Int = 0
    v5 = (v4 - 6)
    return v5
}
fun main() {
    System.exit(spiral_main())
}
