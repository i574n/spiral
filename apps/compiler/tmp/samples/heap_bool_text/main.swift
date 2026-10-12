import CRT
class Heap0 {
    let l0: Bool
    let l1: String
    init(l0: Bool, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Bool = false
    v0 = true
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(l0: false, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Bool = false
    var v4: String = ""
    v3 = v2.l0
    v4 = v2.l1
    var v6: Bool = false
    if (v3) {
        var v5: Bool = false
        v5 = (v4 == "hi")
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
