import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_Missing: US0 { var tag: Int32 { 0 } }
struct US0_Held: US0 { var f0: Array<Int32>; var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: Array<Int32> = Array<Int32>()
    v1 = Array<Int32>(repeating: 0, count: Int(v0))
    var v2: Int32 = 0
    v2 = 7
    v1[Int(0)] = v2
    var v3: Bool = false
    v3 = true
    var v6: US0 = US0_Missing()
    if (v3) {
        v6 = US0_Held(f0: v1)
    } else {
        v6 = US0_Missing()
    }
    switch v6.tag {
        case 1:
            var v7: Array<Int32> = (v6 as! US0_Held).f0
            var v8: Int32 = 0
            v8 = v7[Int(0)]
            var v9: Bool = false
            v9 = (v8 == 7)
            if (v9) {
                return 0
            } else {
                return 1
            }
        case 0:
            return 1
        default:
            fatalError("unreachable union case")
    }
}
exit(spiral_main())
