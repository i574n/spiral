import CRT
class Heap0 {
    let l0: Bool
    init(l0: Bool) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v1: Heap0 = Heap0(l0: false)
    v1 = Heap0(l0: v0)
    var v2: Bool = false
    v2 = v1.l0
    if (v2) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
