import CRT
func sp_method0(_ p0: Int32, _ p1: Int32) -> (Int32, Int32) {
    var v0: Int32 = p0
    var v1: Int32 = p1
    return (v0, v1)
}
func sp_method1(_ p0: Int32, _ p1: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = 0
    v2 = (v0 &+ v1)
    return v2
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 20
    var v1: Int32 = 0
    v1 = 22
    var v2: Int32 = 0
    var v3: Int32 = 0
    let spiral_tuple149 = sp_method0(v0, v1)
    v2 = spiral_tuple149.0
    v3 = spiral_tuple149.1
    var v4: Int32 = 0
    v4 = sp_method1(v2, v3)
    var v5: Int32 = 0
    v5 = (v4 &- 42)
    return v5
}
exit(spiral_main())
