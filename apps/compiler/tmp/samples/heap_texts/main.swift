import CRT
class Heap0 {
    let l0: Array<String>
    init(l0: Array<String>) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Array<String> = Array<String>()
    v0 = Array<String>(repeating: "", count: Int(1))
    var v1: String = ""
    v1 = "hi"
    v0[Int(0)] = v1
    var v2: Heap0 = Heap0(l0: Array<String>())
    v2 = Heap0(l0: v0)
    var v3: Array<String> = Array<String>()
    v3 = v2.l0
    var v4: String = ""
    v4 = v3[Int(0)]
    var v5: Bool = false
    v5 = (v4 == "hi")
    if (v5) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
