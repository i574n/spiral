import CRT
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 1
    var v1: Bool = false
    v1 = (v0 == 1)
    if (v1) {
        "bo$om".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    } else {
        return 0
    }
}
exit(spiral_main())
