import CRT
func sp_f_0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 1)
    if (v1) {
        return 0
    } else {
        return 1
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    return sp_f_0(v0)
}
exit(spiral_main())
