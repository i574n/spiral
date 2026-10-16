import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_Zero: US0 { var tag: Int32 { 0 } }
struct US0_One: US0 { var tag: Int32 { 1 } }
func spiral_main() -> Int32 {
    var v0: US0 = US0_Zero()
    v0 = US0_Zero()
    var v2: Bool = false
    switch v0.tag {
        case 1:
            v2 = false
        case 0:
            v2 = true
        default:
            fatalError("unreachable union case")
    }
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
