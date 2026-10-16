import CRT
func spiral_main() -> Int32 {
    var v0: Array<Int32> = Array<Int32>()
    v0 = Array<Int32>(repeating: 0, count: Int(4))
    v0[Int(0)] = 2
    v0[Int(1)] = 3
    v0[Int(2)] = 5
    v0[Int(3)] = 7
    var v1: Int32 = 0
    v1 = 2
    var v2: Int32 = 0
    v2 = v0[Int(v1)]
    var v3: Int32 = 0
    v3 = (v2 &- 5)
    return v3
}
exit(spiral_main())
