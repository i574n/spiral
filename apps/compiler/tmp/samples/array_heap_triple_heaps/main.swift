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
    let l1: Heap0
    let l2: Heap0
    init(l0: Heap0, l1: Heap0, l2: Heap0) {
        self.l0 = l0
        self.l1 = l1
        self.l2 = l2
    }
}
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 4
    var v4: String = ""
    v4 = "yo"
    var v5: Heap0 = Heap0(l0: 0, l1: "")
    v5 = Heap0(l0: v3, l1: v4)
    var v6: Int32 = 0
    v6 = 9
    var v7: String = ""
    v7 = "ok"
    var v8: Heap0 = Heap0(l0: 0, l1: "")
    v8 = Heap0(l0: v6, l1: v7)
    var v9: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""), l2: Heap0(l0: 0, l1: ""))
    v9 = Heap1(l0: v2, l1: v5, l2: v8)
    var v10: SpiralArray<Heap1> = SpiralArray<Heap1>([])
    v10 = SpiralArray<Heap1>(Array(repeating: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""), l2: Heap0(l0: 0, l1: "")), count: Int(1)))
    v10.items[Int(0)] = v9
    var v11: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""), l2: Heap0(l0: 0, l1: ""))
    v11 = v10.items[Int(0)]
    var v12: Heap0 = Heap0(l0: 0, l1: "")
    var v13: Heap0 = Heap0(l0: 0, l1: "")
    var v14: Heap0 = Heap0(l0: 0, l1: "")
    v12 = v11.l0
    v13 = v11.l1
    v14 = v11.l2
    var v15: Int32 = 0
    var v16: String = ""
    v15 = v12.l0
    v16 = v12.l1
    var v17: Int32 = 0
    var v18: String = ""
    v17 = v13.l0
    v18 = v13.l1
    var v19: Int32 = 0
    var v20: String = ""
    v19 = v14.l0
    v20 = v14.l1
    var v21: Bool = false
    v21 = (v15 == 7)
    var v23: Bool = false
    if (v21) {
        var v22: Bool = false
        v22 = (v16 == "hi")
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        var v24: Bool = false
        v24 = (v17 == 4)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Bool = false
    if (v25) {
        var v26: Bool = false
        v26 = (v18 == "yo")
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Bool = false
    if (v27) {
        var v28: Bool = false
        v28 = (v19 == 9)
        v29 = v28
    } else {
        v29 = false
    }
    var v31: Bool = false
    if (v29) {
        var v30: Bool = false
        v30 = (v20 == "ok")
        v31 = v30
    } else {
        v31 = false
    }
    if (v31) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
