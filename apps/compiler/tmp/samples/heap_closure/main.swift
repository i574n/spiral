import CRT
class Heap0 {
    let l0: (Int32) -> Int32
    init(l0: @escaping (Int32) -> Int32) {
        self.l0 = l0
    }
}
func f_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: Heap0 = Heap0(l0: { (_: Int32) -> Int32 in fatalError("unreachable closure") })
    v2 = Heap0(l0: v1)
    var v3: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v3 = v2.l0
    var v4: Int32 = 0
    v4 = v3(4)
    var v5: Bool = false
    v5 = (v4 == 7)
    if (v5) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
