import CRT
func spiral_main() -> Int32 {
    var v0: UInt32 = UInt32(0)
    v0 = UInt32(65536)
    var v1: UInt32 = UInt32(0)
    v1 = UInt32(65536)
    var v2: UInt32 = UInt32(0)
    v2 = UInt32(4294967295)
    var v3: UInt32 = UInt32(0)
    v3 = UInt32(3)
    var v4: UInt32 = UInt32(0)
    v4 = (v0 &* v1)
    var v5: UInt32 = UInt32(0)
    v5 = (v2 &* v3)
    var v6: Bool = false
    v6 = (v4 == UInt32(0))
    var v8: Bool = false
    if (v6) {
        var v7: Bool = false
        v7 = (v5 == UInt32(4294967293))
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
