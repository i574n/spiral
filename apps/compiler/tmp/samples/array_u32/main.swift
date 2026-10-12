import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Array<UInt32> = Array<UInt32>()
    v1 = Array<UInt32>(repeating: UInt32(0), count: Int(v0))
    v1[Int(0)] = UInt32(4000000000)
    v1[Int(1)] = UInt32(1)
    var v2: UInt32 = UInt32(0)
    v2 = v1[Int(0)]
    var v3: UInt32 = UInt32(0)
    v3 = v1[Int(1)]
    var v4: UInt32 = UInt32(0)
    v4 = (v2 &+ v3)
    var v5: Int32 = 0
    v5 = Int32(v1.count)
    var v6: Bool = false
    v6 = (v5 == v0)
    var v8: Bool = false
    if (v6) {
        var v7: Bool = false
        v7 = (v4 == UInt32(4000000001))
        v8 = v7
    } else {
        v8 = false
    }
    if (v8) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
