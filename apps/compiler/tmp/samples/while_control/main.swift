import CRT
func sp_method0() -> Bool {
    return true
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 0
    var v1: Int32 = 0
    v1 = 0
    while true {
        if !(sp_method0()) { break }
        var v3: Int32 = 0
        v3 = (v0 &+ 1)
        v0 = v3
        var v4: Bool = false
        v4 = (v0 < 3)
        if (v4) {
            continue
        } else {
            var v5: Bool = false
            v5 = (v0 >= 6)
            if (v5) {
                break
            } else {
                var v6: Int32 = 0
                v6 = (v1 &+ v0)
                v1 = v6
            }
        }
    }
    var v7: Int32 = 0
    v7 = (v1 &- 12)
    return v7
}
exit(spiral_main())
