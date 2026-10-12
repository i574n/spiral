import CRT
func spiral_main() -> Int32 {
    var v0: Array<Int8> = Array<Int8>()
    v0 = Array<Int8>(repeating: Int8(0), count: Int(1))
    var v1: Int8 = Int8(0)
    v1 = Int8(100)
    v0[Int(0)] = v1
    var v2: Int8 = Int8(0)
    v2 = v0[Int(0)]
    var v3: Bool = false
    v3 = (v2 == Int8(100))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
