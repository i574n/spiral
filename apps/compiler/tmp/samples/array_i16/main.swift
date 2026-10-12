import CRT
func spiral_main() -> Int32 {
    var v0: Array<Int16> = Array<Int16>()
    v0 = Array<Int16>(repeating: Int16(0), count: Int(1))
    var v1: Int16 = Int16(0)
    v1 = Int16(20000)
    v0[Int(0)] = v1
    var v2: Int16 = Int16(0)
    v2 = v0[Int(0)]
    var v3: Bool = false
    v3 = (v2 == Int16(20000))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
