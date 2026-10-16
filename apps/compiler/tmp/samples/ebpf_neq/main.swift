import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: UInt32 = UInt32(0)
    v2 = UInt32(1)
    var v3: UInt32 = UInt32(0)
    v3 = UInt32(1)
    var v4: Float = (0.0 as Float)
    v4 = (1.5 as Float)
    var v5: Float = (0.0 as Float)
    v5 = (-(v4))
    var v6: Bool = false
    v6 = (v0 == v1)
    var v7: Bool = false
    v7 = (v6 != true)
    if (v7) {
        var v8: Bool = false
        v8 = (v2 == v3)
        var v9: Bool = false
        v9 = (v8 != true)
        if (v9) {
            return 2
        } else {
            var v10: Bool = false
            v10 = (v5 == (-1.5 as Float))
            if (v10) {
                return 0
            } else {
                return 3
            }
        }
    } else {
        return 1
    }
}
exit(spiral_main())
