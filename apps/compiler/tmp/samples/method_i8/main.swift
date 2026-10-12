import CRT
func sp_method0(_ p0: Int8) -> Int8 {
    var v0: Int8 = p0
    var v1: Bool = false
    v1 = (v0 == Int8(0))
    if (v1) {
        return Int8(1)
    } else {
        return v0
    }
}
func spiral_main() -> Int32 {
    var v0: Int8 = Int8(0)
    v0 = Int8(100)
    var v1: Int8 = Int8(0)
    v1 = sp_method0(v0)
    var v2: Bool = false
    v2 = (v1 == Int8(100))
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
