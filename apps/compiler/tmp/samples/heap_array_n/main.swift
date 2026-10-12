import CRT
class Heap0 {
    let l0: Array<Int32>
    let l1: Int32
    init(l0: Array<Int32>, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 3
    var v1: Int32 = 0
    v1 = 4
    var v2: Array<Int32> = Array<Int32>()
    v2 = Array<Int32>(repeating: 0, count: Int(1))
    v2[Int(0)] = v0
    var v3: Heap0 = Heap0(l0: Array<Int32>(), l1: 0)
    v3 = Heap0(l0: v2, l1: v1)
    var v4: Array<Int32> = Array<Int32>()
    var v5: Int32 = 0
    v4 = v3.l0
    v5 = v3.l1
    var v6: Int32 = 0
    v6 = v4[Int(0)]
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
