import CRT
func spiral_main() -> Int32 {
    var v0: Array<UInt64> = Array<UInt64>()
    v0 = Array<UInt64>(repeating: (0 as UInt64), count: Int(1))
    var v1: UInt64 = (0 as UInt64)
    v1 = (4294967297 as UInt64)
    v0[Int(0)] = v1
    var v2: UInt64 = (0 as UInt64)
    v2 = v0[Int(0)]
    var v3: Bool = false
    v3 = (v2 == (4294967297 as UInt64))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
