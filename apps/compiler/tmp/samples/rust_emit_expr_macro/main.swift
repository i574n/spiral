import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 20
    var v1: Int32 = 0
    v1 = 2
    var v2: Int32 = 0
    v2 = (v0 &* v1)
    var v3: Int32 = 0
    v3 = (v2 &+ 3)
    return v3
}
exit(spiral_main())
