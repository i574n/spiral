import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 5
    var v1: Array<Int32> = Array<Int32>()
    v1 = Array<Int32>(repeating: 0, count: Int(v0))
    v1[Int(0)] = 0
    v1[Int(1)] = 1
    v1[Int(2)] = 4
    var v2: Int32 = 0
    v2 = 3
    v1[Int(v2)] = 9
    var v3: Int32 = 0
    v3 = (v2 &+ 1)
    v1[Int(v3)] = 16
    var v4: Array<Bool> = Array<Bool>()
    v4 = Array<Bool>(repeating: false, count: Int(3))
    v4[Int(0)] = false
    v4[Int(1)] = true
    v4[Int(2)] = false
    var v5: Int32 = 0
    v5 = v1[Int(1)]
    var v6: Int32 = 0
    v6 = v1[Int(2)]
    var v7: Int32 = 0
    v7 = (v5 &+ v6)
    var v8: Int32 = 0
    v8 = v1[Int(3)]
    var v9: Int32 = 0
    v9 = (v7 &+ v8)
    var v10: Int32 = 0
    v10 = v1[Int(4)]
    var v11: Int32 = 0
    v11 = (v9 &+ v10)
    var v12: Bool = false
    v12 = v4[Int(1)]
    var v15: Int32 = 0
    if (v12) {
        var v13: Bool = false
        v13 = v4[Int(0)]
        if (v13) {
            v15 = 0
        } else {
            v15 = 100
        }
    } else {
        v15 = 0
    }
    var v16: Int32 = 0
    v16 = (v11 &+ v15)
    var v17: Int32 = 0
    v17 = Int32(v1.count)
    var v18: Int32 = 0
    v18 = (v16 &+ v17)
    return v18
}
exit(spiral_main())
