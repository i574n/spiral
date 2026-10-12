import CRT
func spiral_main() -> Int32 {
    var v0: Array<UInt16> = Array<UInt16>()
    v0 = Array<UInt16>(repeating: UInt16(0), count: Int(1))
    var v1: UInt16 = UInt16(0)
    v1 = UInt16(40000)
    v0[Int(0)] = v1
    var v2: UInt16 = UInt16(0)
    v2 = v0[Int(0)]
    var v3: Bool = false
    v3 = (v2 == UInt16(40000))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
