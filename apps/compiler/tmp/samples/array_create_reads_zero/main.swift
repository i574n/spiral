import CRT
func spiral_main() -> Int32 {
    var v0: Array<Int32> = Array<Int32>()
    v0 = Array<Int32>(repeating: 0, count: Int(4))
    v0[Int(0)] = 7
    v0[Int(1)] = 7
    v0[Int(2)] = 7
    v0[Int(3)] = 7
    var v1: Int32 = 0
    v1 = v0[Int(3)]
    var v2: Array<Int32> = Array<Int32>()
    v2 = Array<Int32>(repeating: 0, count: Int(4))
    v2[Int(0)] = 5
    var v3: Int32 = 0
    v3 = v2[Int(3)]
    var v4: Int32 = 0
    v4 = v2[Int(0)]
    var v5: Int32 = 0
    v5 = (v3 &* 100)
    var v6: Int32 = 0
    v6 = (v5 &+ v4)
    var v7: Int32 = 0
    v7 = (v1 &- 7)
    var v8: Int32 = 0
    v8 = (v6 &+ v7)
    return v8
}
exit(spiral_main())
