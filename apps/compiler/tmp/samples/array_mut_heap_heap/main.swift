import CRT
import WinSDK
class Heap0 {
    let l0: Int32
    let l1: String
    init(l0: Int32, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
class Heap1 {
    let l0: Heap0
    let l1: Int32
    init(l0: Heap0, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
class Mut2 {
    var l0: Heap1
    init(l0: Heap1) {
        self.l0 = l0
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: String = "no"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 1
    let v4: Heap1 = Heap1(l0: v2, l1: v3)
    let v5: Mut2 = Mut2(l0: v4)
    var v6: SpiralArray<Mut2> = SpiralArray<Mut2>([])
    v6 = SpiralArray<Mut2>(Array(repeating: Mut2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)), count: Int(1)))
    v6.items[Int(0)] = v5
    let v7: Int32 = 7
    let v8: String = "hi"
    let v9: Heap0 = Heap0(l0: v7, l1: v8)
    let v10: Int32 = 4
    let v11: Heap1 = Heap1(l0: v9, l1: v10)
    var v12: Mut2 = Mut2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0))
    v12 = v6.items[Int(0)]
    v12.l0 = v11
    let v13: Heap1 = v12.l0
    var v14: Heap0 = Heap0(l0: 0, l1: "")
    var v15: Int32 = 0
    v14 = v13.l0
    v15 = v13.l1
    var v16: Int32 = 0
    var v17: String = ""
    v16 = v14.l0
    v17 = v14.l1
    let v18: Bool = (v16 == 7)
    var v20: Bool = false
    if (v18) {
        let v19: Bool = (v17 == "hi")
        v20 = v19
    } else {
        v20 = false
    }
    var v22: Bool = false
    if (v20) {
        let v21: Bool = (v15 == 4)
        v22 = v21
    } else {
        v22 = false
    }
    if (v22) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
