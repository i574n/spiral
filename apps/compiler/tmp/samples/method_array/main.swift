import CRT
func sp_method0(_ p0: Int32) -> Array<Int32> {
    var v0: Int32 = p0
    var v1: Array<Int32> = Array<Int32>()
    v1 = Array<Int32>(repeating: 0, count: Int(1))
    v1[Int(0)] = v0
    return v1
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: Array<Int32> = Array<Int32>()
    v1 = sp_method0(v0)
    var v2: Int32 = 0
    v2 = v1[Int(0)]
    var v3: Bool = false
    v3 = (v2 == 7)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
