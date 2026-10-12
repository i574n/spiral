fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 4
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 10
    v1[1] = 20
    v1[2] = 30
    var v2: Int = 0
    v2 = v1[0]
    var v3: Int = 0
    v3 = v1[1]
    var v4: Int = 0
    v4 = (v2 + v3)
    v1[3] = v4
    var v5: Int = 0
    v5 = v1[2]
    var v6: Int = 0
    v6 = v1[3]
    var v7: Int = 0
    v7 = (v5 + v6)
    var v8: Int = 0
    v8 = v1.size
    var v9: Boolean = false
    v9 = (v8 == v0)
    var v11: Boolean = false
    if (v9) {
        var v10: Boolean = false
        v10 = (v7 == 60)
        v11 = v10
    } else {
        v11 = false
    }
    if (v11) {
        return 0
    } else {
        return 1
    }
}
fun main() {
    System.exit(spiral_main())
}
