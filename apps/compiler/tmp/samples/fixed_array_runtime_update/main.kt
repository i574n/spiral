fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(4) { 0 }
    v0[0] = 2
    v0[1] = 3
    v0[2] = 5
    v0[3] = 7
    var v1: Int = 0
    v1 = 1
    v0[v1] = 11
    var v2: Int = 0
    v2 = v0[0]
    var v3: Int = 0
    v3 = v0[1]
    var v4: Int = 0
    v4 = v0[2]
    var v5: Int = 0
    v5 = v0[3]
    var v6: Int = 0
    v6 = (v2 + v3)
    var v7: Int = 0
    v7 = (v6 + v4)
    var v8: Int = 0
    v8 = (v7 + v5)
    var v9: Int = 0
    v9 = (v8 - 25)
    return v9
}
fun main() {
    System.exit(spiral_main())
}
