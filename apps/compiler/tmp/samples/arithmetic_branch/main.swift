import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 6
    var v1: Int32 = 0
    v1 = 7
    var v2: Int32 = 0
    v2 = (v0 &* v1)
    var v3: Bool = false
    v3 = (v2 == 42)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
