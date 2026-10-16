import CRT
func sp_loop_0(_ p0: Int32, _ p1: Array<Int32>, _ p2: Int32, _ p3: Int32, _ p4: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Array<Int32> = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    var v4: Int32 = p4
    while true {
        var v5: Bool = false
        v5 = (v3 >= v0)
        if (v5) {
            return v4
        } else {
            var v6: Int32 = 0
            v6 = (v3 % 4)
            var v7: Int32 = 0
            v7 = v1[Int(v6)]
            var v8: Int32 = 0
            v8 = (v3 &+ 1)
            var v9: Int32 = 0
            v9 = (v4 &* 7)
            var v10: Int32 = 0
            v10 = (v9 &+ v7)
            var v11: Int32 = 0
            v11 = (v10 &+ v2)
            var v12: Int32 = 0
            v12 = (v11 % 9973)
            let t785_0: Int32 = v0
            let t821_1: Array<Int32> = v1
            let t864_2: Int32 = v2
            let t900_8: Int32 = v8
            let t936_12: Int32 = v12
            v0 = t785_0
            v1 = t821_1
            v2 = t864_2
            v3 = t900_8
            v4 = t936_12
            continue
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    var v0: Array<Int32> = Array<Int32>()
    v0 = Array<Int32>(repeating: 0, count: Int(4))
    v0[Int(0)] = 1
    v0[Int(1)] = 2
    v0[Int(2)] = 3
    v0[Int(3)] = 4
    var v1: Int32 = 0
    v1 = 0
    var v2: Int32 = 0
    v2 = 1000000
    var v3: Int32 = 0
    v3 = 0
    var v4: Int32 = 0
    v4 = 0
    var v5: Int32 = 0
    v5 = sp_loop_0(v2, v0, v1, v3, v4)
    var v6: Int32 = 0
    v6 = (v5 % 256)
    return v6
}
exit(spiral_main())
