import CRT
func spiral_main() -> Int32 {
    var v0: Int64 = (0 as Int64)
    v0 = (3000000000 as Int64)
    var v1: Bool = false
    v1 = (v0 > (2999999999 as Int64))
    if (v1) {
        return 7
    } else {
        return 0
    }
}
exit(spiral_main())
