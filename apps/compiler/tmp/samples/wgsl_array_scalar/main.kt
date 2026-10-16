fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 5
    var v1: Array<Int> = emptyArray<Int>()
    v1 = Array(v0) { 0 }
    v1[0] = 0
    v1[1] = 1
    v1[2] = 4
    var v2: Int = 0
    v2 = 3
    v1[v2] = 9
    var v3: Int = 0
    v3 = (v2 + 1)
    v1[v3] = 16
    var v4: Array<Boolean> = emptyArray<Boolean>()
    v4 = Array(3) { false }
    v4[0] = false
    v4[1] = true
    v4[2] = false
    var v5: Int = 0
    v5 = v1[1]
    var v6: Int = 0
    v6 = v1[2]
    var v7: Int = 0
    v7 = (v5 + v6)
    var v8: Int = 0
    v8 = v1[3]
    var v9: Int = 0
    v9 = (v7 + v8)
    var v10: Int = 0
    v10 = v1[4]
    var v11: Int = 0
    v11 = (v9 + v10)
    var v12: Boolean = false
    v12 = v4[1]
    var v15: Int = 0
    if (v12) {
        var v13: Boolean = false
        v13 = v4[0]
        if (v13) {
            v15 = 0
        } else {
            v15 = 100
        }
    } else {
        v15 = 0
    }
    var v16: Int = 0
    v16 = (v11 + v15)
    var v17: Int = 0
    v17 = v1.size
    var v18: Int = 0
    v18 = (v16 + v17)
    return v18
}
fun main() {
    System.exit(spiral_main())
}
