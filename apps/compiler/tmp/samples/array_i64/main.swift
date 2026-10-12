import CRT
func spiral_main() -> Int32 {
    var v0: Array<Int64> = Array<Int64>()
    v0 = Array<Int64>(repeating: (0 as Int64), count: Int(1))
    var v1: Int64 = (0 as Int64)
    v1 = (5000000000 as Int64)
    v0[Int(0)] = v1
    var v2: Int64 = (0 as Int64)
    v2 = v0[Int(0)]
    var v3: Bool = false
    v3 = (v2 == (5000000000 as Int64))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
