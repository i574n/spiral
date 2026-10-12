import CRT
func spiral_main() -> Int32 {
    var v0: Array<Bool> = Array<Bool>()
    v0 = Array<Bool>(repeating: false, count: Int(1))
    var v1: Bool = false
    v1 = true
    v0[Int(0)] = v1
    var v2: Bool = false
    v2 = v0[Int(0)]
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
