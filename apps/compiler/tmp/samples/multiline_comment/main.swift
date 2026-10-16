import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Int32 = 0
    v1 = (v0 &* 2)
    var v2: Bool = false
    v2 = (v1 == 14)
    var v3: Bool = false
    v3 = (v2 != true)
    if (v3) {
        return 1
    } else {
        return 0
    }
}
exit(spiral_main())
