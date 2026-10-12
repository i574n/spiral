import CRT
func spiral_main() -> Int32 {
    var v0: Array<String> = Array<String>()
    v0 = Array<String>(repeating: "", count: Int(2))
    var v1: String = ""
    v1 = "hi"
    v0[Int(1)] = v1
    var v2: String = ""
    v2 = v0[Int(1)]
    var v3: Bool = false
    v3 = (v2 == "hi")
    if (v3) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
