import CRT
func sp_method0(_ p0: Int32, _ p1: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = (v0 &+ v1)
    var v3: Int32 = 0
    v3 = (v2 &- 42)
    return v3
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 20
    var v1: Int32 = 0
    v1 = 22
    return sp_method0(v0, v1)
}
exit(spiral_main())
