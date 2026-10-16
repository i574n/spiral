fun spiral_main(): Int {
    var v0: Array<Int> = emptyArray<Int>()
    v0 = Array(4) { 0 }
    v0[0] = 7
    v0[1] = 7
    v0[2] = 7
    v0[3] = 7
    var v1: Int = 0
    v1 = v0[3]
    var v2: Array<Int> = emptyArray<Int>()
    v2 = Array(4) { 0 }
    v2[0] = 5
    var v3: Int = 0
    v3 = v2[3]
    var v4: Int = 0
    v4 = v2[0]
    var v5: Int = 0
    v5 = (v3 * 100)
    var v6: Int = 0
    v6 = (v5 + v4)
    var v7: Int = 0
    v7 = (v1 - 7)
    var v8: Int = 0
    v8 = (v6 + v7)
    return v8
}
fun main() {
    System.exit(spiral_main())
}
