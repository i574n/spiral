import CRT
class Heap0 {
    let l0: Int8
    init(l0: Int8) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Int8 = Int8(0)
    v0 = Int8(100)
    var v1: Heap0 = Heap0(l0: Int8(0))
    v1 = Heap0(l0: v0)
    var v2: Int8 = Int8(0)
    v2 = v1.l0
    var v3: Bool = false
    v3 = (v2 == Int8(100))
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
