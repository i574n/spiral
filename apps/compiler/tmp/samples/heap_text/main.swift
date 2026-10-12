import CRT
class Heap0 {
    let l0: String
    init(l0: String) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "hi"
    var v1: Heap0 = Heap0(l0: "")
    v1 = Heap0(l0: v0)
    var v2: String = ""
    v2 = v1.l0
    var v3: Bool = false
    v3 = (v2 == "hi")
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
