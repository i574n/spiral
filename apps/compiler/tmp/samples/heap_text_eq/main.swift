import CRT
class Heap0 {
    let l0: String
    let l1: String
    init(l0: String, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "hi"
    var v1: Heap0 = Heap0(l0: "", l1: "")
    v1 = Heap0(l0: v0, l1: v0)
    var v2: String = ""
    var v3: String = ""
    v2 = v1.l0
    v3 = v1.l1
    var v4: Bool = false
    v4 = (v2 == v3)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
