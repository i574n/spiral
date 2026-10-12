import CRT
func sp_method0(_ p0: Int32) -> Bool {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 < 10)
    return v1
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 0
    var v1: Int32 = 0
    v1 = 0
    while true {
        if !(sp_method0(v0)) { break }
        var v3: Int32 = 0
        v3 = (v1 &+ v0)
        v1 = v3
        var v4: Int32 = 0
        v4 = (v0 &+ 1)
        v0 = v4
    }
    var v5: Int32 = 0
    v5 = (v1 &- 45)
    return v5
}
exit(spiral_main())
