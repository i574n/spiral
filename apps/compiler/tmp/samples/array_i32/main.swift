import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 4
    var v1: Array<Int32> = Array<Int32>()
    v1 = Array<Int32>(repeating: 0, count: Int(v0))
    v1[Int(0)] = 10
    v1[Int(1)] = 20
    v1[Int(2)] = 30
    var v2: Int32 = 0
    v2 = v1[Int(0)]
    var v3: Int32 = 0
    v3 = v1[Int(1)]
    var v4: Int32 = 0
    v4 = (v2 &+ v3)
    v1[Int(3)] = v4
    var v5: Int32 = 0
    v5 = v1[Int(2)]
    var v6: Int32 = 0
    v6 = v1[Int(3)]
    var v7: Int32 = 0
    v7 = (v5 &+ v6)
    var v8: Int32 = 0
    v8 = Int32(v1.count)
    var v9: Bool = false
    v9 = (v8 == v0)
    var v11: Bool = false
    if (v9) {
        var v10: Bool = false
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
exit(spiral_main())
