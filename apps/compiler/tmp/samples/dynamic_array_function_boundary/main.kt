fun sp_method0(p0: Array<Int>, p1: Int): Int {
    var v0: Array<Int> = p0
    var v1: Int = p1
    var v2: Int = 0
    v2 = v0[v1]
    var v3: Int = 0
    v3 = v0.size
    var v4: Int = 0
    v4 = (v2 + v3)
    var v5: Int = 0
    v5 = (v4 - 10)
    return v5
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 3
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 2
    v1[1] = 5
    v1[2] = 7
    var v2: Int = 0
    v2 = 2
    return sp_method0(v1, v2)
}
fun main() {
    System.exit(spiral_main())
}
