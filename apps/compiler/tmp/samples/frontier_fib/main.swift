import CRT
func sp_fib_0(_ p0: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 <= 1)
    if (v1) {
        return v0
    } else {
        var v2: Int32 = 0
        v2 = (v0 &- 1)
        var v3: Int32 = 0
        v3 = sp_fib_0(v2)
        var v4: Int32 = 0
        v4 = (v0 &- 2)
        var v5: Int32 = 0
        v5 = sp_fib_0(v4)
        var v6: Int32 = 0
        v6 = (v3 &+ v5)
        return v6
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 10
    var v1: Int32 = 0
    v1 = sp_fib_0(v0)
    var v2: Int32 = 0
    v2 = (v1 &- 55)
    return v2
}
exit(spiral_main())
