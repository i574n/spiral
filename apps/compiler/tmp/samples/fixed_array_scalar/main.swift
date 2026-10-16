import CRT
func spiral_main() -> Int32 {
    var v0: Array<Int32> = Array<Int32>()
    v0 = Array<Int32>(repeating: 0, count: Int(3))
    v0[Int(0)] = 2
    v0[Int(1)] = 3
    v0[Int(2)] = 5
    var v1: Int32 = 0
    v1 = v0[Int(0)]
    var v2: Int32 = 0
    v2 = v0[Int(1)]
    var v3: Int32 = 0
    v3 = v0[Int(2)]
    var v4: Int32 = 0
    v4 = (v1 &+ v2)
    var v5: Int32 = 0
    v5 = (v4 &+ v3)
    var v6: Int32 = 0
    v6 = (v5 &- 10)
    return v6
}
exit(spiral_main())
