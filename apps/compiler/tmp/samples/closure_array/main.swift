import CRT
func f_c0(_ v0: Int32) -> (Int32) -> Array<Int32> {
    return { (v1: Int32) -> Array<Int32> in
        var v2: Array<Int32> = Array<Int32>()
        v2 = Array<Int32>(repeating: 0, count: Int(1))
        v2[Int(0)] = v0
        return v2
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: (Int32) -> Array<Int32> = { (_: Int32) -> Array<Int32> in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: Array<Int32> = Array<Int32>()
    v2 = v1(1)
    var v3: Int32 = 0
    v3 = v2[Int(0)]
    var v4: Bool = false
    v4 = (v3 == 7)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
