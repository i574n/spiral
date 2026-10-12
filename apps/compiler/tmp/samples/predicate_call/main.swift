import CRT
func sp_is_answer_1(_ p0: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 42)
    return v1
}
func sp_method0(_ p0: Int32) -> Bool {
    var v0: Int32 = p0
    return sp_is_answer_1(v0)
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 42
    var v1: Bool = false
    v1 = sp_method0(v0)
    if (v1) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
