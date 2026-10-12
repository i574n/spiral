import CRT
class Heap0 {
    let l0: Array<Int32>
    init(l0: Array<Int32>) {
        self.l0 = l0
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 2
    var v1: Array<Int32> = Array<Int32>()
    v1 = Array<Int32>(repeating: 0, count: Int(v0))
    var v2: Int32 = 0
    v2 = 7
    v1[Int(0)] = v2
    var v3: Heap0 = Heap0(l0: Array<Int32>())
    v3 = Heap0(l0: v1)
    var v4: Array<Int32> = Array<Int32>()
    v4 = v3.l0
    var v5: Int32 = 0
    v5 = v4[Int(0)]
    var v6: Bool = false
    v6 = (v5 == 7)
    if (v6) {
        return 0
    } else {
        return 1
    }
}
exit(spiral_main())
