import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = -1
    var v1: Int32 = 0
    v1 = -8
    var v2: Int32 = 0
    v2 = (~(v0))
    var v3: Int32 = 0
    v3 = (~(v1))
    var v4: Bool = false
    v4 = (v2 == 0)
    var v6: Bool = false
    if (v4) {
        var v5: Bool = false
        v5 = (v3 == 7)
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
