import CRT
func spiral_main() -> Int32 {
    var v0: Array<Int32> = Array<Int32>()
    v0 = Array<Int32>(repeating: 0, count: Int(4))
    v0[Int(0)] = 2
    v0[Int(1)] = 3
    v0[Int(2)] = 5
    v0[Int(3)] = 7
    var v1: Int32 = 0
    v1 = 1
    v0[Int(v1)] = 11
    var v2: Int32 = 0
    v2 = v0[Int(0)]
    var v3: Int32 = 0
    v3 = v0[Int(1)]
    var v4: Int32 = 0
    v4 = v0[Int(2)]
    var v5: Int32 = 0
    v5 = v0[Int(3)]
    var v6: Int32 = 0
    v6 = (v2 &+ v3)
    var v7: Int32 = 0
    v7 = (v6 &+ v4)
    var v8: Int32 = 0
    v8 = (v7 &+ v5)
    var v9: Int32 = 0
    v9 = (v8 &- 25)
    return v9
}
exit(spiral_main())
