import CRT
class Heap0 {
    let l0: Array<String>
    let l1: Bool
    init(l0: Array<String>, l1: Bool) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Array<String> = Array<String>()
    v0 = Array<String>(repeating: "", count: Int(1))
    var v1: String = ""
    v1 = "hi"
    v0[Int(0)] = v1
    var v2: Bool = false
    v2 = true
    var v3: Heap0 = Heap0(l0: Array<String>(), l1: false)
    v3 = Heap0(l0: v0, l1: v2)
    var v4: Array<String> = Array<String>()
    var v5: Bool = false
    v4 = v3.l0
    v5 = v3.l1
    var v6: String = ""
    v6 = v4[Int(0)]
    var v7: Bool = false
    v7 = (v6 == "hi")
    var v8: Bool = false
    v8 = (v7 && v5)
    if (v8) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
