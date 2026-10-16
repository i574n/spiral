import CRT
protocol US0 { var tag: Int32 { get } }
struct US0_Living: US0 { var f0: Int32; var f1: Int32; var tag: Int32 { 0 } }
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Array<US0> = Array<US0>()
    v1 = Array<US0>(repeating: US0_Living(f0: 0, f1: 0), count: Int(v0))
    return 0
}
exit(spiral_main())
