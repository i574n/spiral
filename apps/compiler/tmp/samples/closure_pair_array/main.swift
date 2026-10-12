import CRT
func f_c0(_ v0: Int32, _ v1: Int32) -> (Int32) -> (Array<Int32>, Array<Int32>) {
    return { (v2: Int32) -> (Array<Int32>, Array<Int32>) in
        var v3: Array<Int32> = Array<Int32>()
        v3 = Array<Int32>(repeating: 0, count: Int(1))
        var v4: Array<Int32> = Array<Int32>()
        v4 = Array<Int32>(repeating: 0, count: Int(1))
        var v5: Bool = false
        v5 = (v2 == 0)
        if (v5) {
            v3[Int(0)] = 0
            v4[Int(0)] = 0
            return (v3, v4)
        } else {
            v3[Int(0)] = v0
            v4[Int(0)] = v1
            return (v3, v4)
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: (Int32) -> (Array<Int32>, Array<Int32>) = { (_: Int32) -> (Array<Int32>, Array<Int32>) in fatalError("unreachable closure") }
    v2 = f_c0(v0, v1)
    var v3: Array<Int32> = Array<Int32>()
    var v4: Array<Int32> = Array<Int32>()
    let spiral_tuple349 = v2(1)
    v3 = spiral_tuple349.0
    v4 = spiral_tuple349.1
    var v5: Int32 = 0
    v5 = v3[Int(0)]
    var v6: Int32 = 0
    v6 = v4[Int(0)]
    var v7: Int32 = 0
    v7 = (v5 &+ v6)
    var v8: Bool = false
    v8 = (v7 == 7)
    if (v8) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
