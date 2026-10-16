import CRT
func spiral_main() -> Int32 {
    var v0: UInt32 = UInt32(0)
    v0 = UInt32(2147483647)
    var v1: UInt32 = UInt32(0)
    v1 = UInt32(2)
    var v2: UInt32 = UInt32(0)
    v2 = UInt32(1)
    var v3: UInt32 = UInt32(0)
    v3 = (v0 &+ v1)
    var v4: UInt32 = UInt32(0)
    v4 = (v0 &+ v2)
    var v5: Bool = false
    v5 = (v3 == UInt32(2147483649))
    var v7: Bool = false
    if (v5) {
        var v6: Bool = false
        v6 = (v4 == UInt32(2147483648))
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
