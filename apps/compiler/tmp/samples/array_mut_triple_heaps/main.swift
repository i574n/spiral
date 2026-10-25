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
class Mut1 {
    var l0: Heap0
    var l1: Heap0
    var l2: Heap0
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
    v0 = 1
    var v1: String = ""
    v1 = "no"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 2
    var v4: String = ""
    v4 = "zz"
    var v5: Heap0 = Heap0(l0: 0, l1: "")
    v5 = Heap0(l0: v3, l1: v4)
    var v6: Int32 = 0
    v6 = 3
    var v7: String = ""
    v7 = "aa"
    var v8: Heap0 = Heap0(l0: 0, l1: "")
    v8 = Heap0(l0: v6, l1: v7)
    var v9: Mut1 = Mut1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""), l2: Heap0(l0: 0, l1: ""))
    v9 = Mut1(l0: v2, l1: v5, l2: v8)
    var v10: SpiralArray<Mut1> = SpiralArray<Mut1>([])
    v10 = SpiralArray<Mut1>(Array(repeating: Mut1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""), l2: Heap0(l0: 0, l1: "")), count: Int(1)))
    v10.items[Int(0)] = v9
    var v11: Int32 = 0
    v11 = 7
    var v12: String = ""
    v12 = "hi"
    var v13: Heap0 = Heap0(l0: 0, l1: "")
    v13 = Heap0(l0: v11, l1: v12)
    var v14: Int32 = 0
    v14 = 4
    var v15: String = ""
    v15 = "yo"
    var v16: Heap0 = Heap0(l0: 0, l1: "")
    v16 = Heap0(l0: v14, l1: v15)
    var v17: Int32 = 0
    v17 = 9
    var v18: String = ""
    v18 = "ok"
    var v19: Heap0 = Heap0(l0: 0, l1: "")
    v19 = Heap0(l0: v17, l1: v18)
    var v20: Mut1 = Mut1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""), l2: Heap0(l0: 0, l1: ""))
    v20 = v10.items[Int(0)]
    v20.l0 = v13
    v20.l1 = v16
    v20.l2 = v19
    var v21: Heap0 = Heap0(l0: 0, l1: "")
    var v22: Heap0 = Heap0(l0: 0, l1: "")
    var v23: Heap0 = Heap0(l0: 0, l1: "")
    v21 = v20.l0
    v22 = v20.l1
    v23 = v20.l2
    var v24: Int32 = 0
    var v25: String = ""
    v24 = v21.l0
    v25 = v21.l1
    var v26: Int32 = 0
    var v27: String = ""
    v26 = v22.l0
    v27 = v22.l1
    var v28: Int32 = 0
    var v29: String = ""
    v28 = v23.l0
    v29 = v23.l1
    var v30: Bool = false
    v30 = (v24 == 7)
    var v32: Bool = false
    if (v30) {
        var v31: Bool = false
        v31 = (v25 == "hi")
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Bool = false
    if (v32) {
        var v33: Bool = false
        v33 = (v26 == 4)
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Bool = false
    if (v34) {
        var v35: Bool = false
        v35 = (v27 == "yo")
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Bool = false
    if (v36) {
        var v37: Bool = false
        v37 = (v28 == 9)
        v38 = v37
    } else {
        v38 = false
    }
    var v40: Bool = false
    if (v38) {
        var v39: Bool = false
        v39 = (v29 == "ok")
        v40 = v39
    } else {
        v40 = false
    }
    if (v40) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
