fun sp_method0(p0: Int): Int {
    var v0: Int = p0
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 2
    v1[1] = 3
    v1[2] = 5
    v1[3] = 7
    var v2: Int = 0
    v2 = 2
    var v3: Int = 0
    v3 = v1[v2]
    var v4: Int = 0
    v4 = v1.size
    var v5: Int = 0
    v5 = (v3 + v4)
    var v6: Int = 0
    v6 = (v5 - 9)
    return v6
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 4
    return sp_method0(v0)
}
fun main() {
    System.exit(spiral_main())
}
