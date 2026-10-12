import CRT
func spiral_main() -> Int32 {
    var v0: Array<UInt8> = Array<UInt8>()
    v0 = Array<UInt8>(repeating: UInt8(0), count: Int(1))
    var v1: UInt8 = UInt8(0)
    v1 = UInt8(200)
    v0[Int(0)] = v1
    var v2: UInt8 = UInt8(0)
    v2 = v0[Int(0)]
    var v3: Bool = false
    v3 = (v2 == UInt8(200))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
