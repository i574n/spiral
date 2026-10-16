import CRT
func spiral_main() -> Int32 {
    var v0: UInt32 = UInt32(0)
    v0 = UInt32(1)
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = 31
    var v3: UInt32 = UInt32(0)
    v3 = (v0 << v2)
    var v4: UInt32 = UInt32(0)
    v4 = (v3 >> v2)
    var v5: UInt32 = UInt32(0)
    v5 = (v0 << v1)
    var v6: Bool = false
    v6 = (v3 == UInt32(2147483648))
    var v8: Bool = false
    if (v6) {
        var v7: Bool = false
        v7 = (v4 == UInt32(1))
        v8 = v7
    } else {
        v8 = false
    }
    var v10: Bool = false
    if (v8) {
        var v9: Bool = false
        v9 = (v5 == UInt32(1))
        v10 = v9
    } else {
        v10 = false
    }
    if (v10) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
