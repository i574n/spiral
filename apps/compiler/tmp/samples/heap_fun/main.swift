import CRT
class Heap0 {
    let l0: (Int32) -> Int32
    let l1: Int32
    init(l0: @escaping (Int32) -> Int32, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func add_c0(_ v0: Int32) -> (Int32) -> Int32 {
    return { (v1: Int32) -> Int32 in
        var v2: Int32 = 0
        v2 = (v1 &+ v0)
        return v2
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    v2 = add_c0(v0)
    var v3: Heap0 = Heap0(l0: { (_: Int32) -> Int32 in fatalError("unreachable closure") }, l1: 0)
    v3 = Heap0(l0: v2, l1: v1)
    var v4: (Int32) -> Int32 = { (_: Int32) -> Int32 in fatalError("unreachable closure") }
    var v5: Int32 = 0
    v4 = v3.l0
    v5 = v3.l1
    var v6: Int32 = 0
    v6 = v4(0)
    var v7: Int32 = 0
    v7 = (v6 &+ v5)
    var v8: Bool = false
    v8 = (v7 == 7)
    if (v8) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
