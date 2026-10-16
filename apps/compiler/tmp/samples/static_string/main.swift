import CRT
func sp_method0(_ p0: String) -> Bool {
    var v0: String = p0
    return true
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "spiral"
    var v1: Bool = false
    v1 = sp_method0(v0)
    if (v1) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
