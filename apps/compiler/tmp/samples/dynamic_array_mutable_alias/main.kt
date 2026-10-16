fun sp_method0(p0: Array<Int>) {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = 1
    var v2: Int = 0
    v2 = 9
    v0[v1] = v2
}
fun sp_method1(p0: Array<Int>): Int {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = 0
    var v2: Int = 0
    v2 = v0[v1]
    return v2
}
fun sp_method2(p0: Array<Int>): Int {
    var v0: Array<Int> = p0
    var v1: Int = 0
    v1 = 1
    var v2: Int = 0
    v2 = v0[v1]
    return v2
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 2
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 1
    v1[1] = 2
    sp_method0(v1)
    var v2: Int = 0
    v2 = sp_method1(v1)
    var v3: Int = 0
    v3 = sp_method2(v1)
    var v4: Int = 0
    v4 = (v2 + v3)
    var v5: Int = 0
    v5 = (v4 - 10)
    return v5
}
fun main() {
    System.exit(spiral_main())
}
