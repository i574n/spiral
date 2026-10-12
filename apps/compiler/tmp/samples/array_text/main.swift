import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: Array<String> = Array<String>()
    v1 = Array<String>(repeating: "", count: Int(v0))
    var v2: String = ""
    v2 = "hi"
    v1[Int(0)] = v2
    var v3: String = ""
    v3 = "yo"
    v1[Int(1)] = v3
    var v4: String = ""
    v4 = v1[Int(0)]
    var v5: Bool = false
    v5 = (v4 == "hi")
    if (v5) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
