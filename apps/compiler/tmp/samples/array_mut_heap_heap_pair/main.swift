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
    init(l0: Heap0, l1: Heap0) {
        self.l0 = l0
        self.l1 = l1
    }
}
class Heap2 {
    let l0: Heap1
    let l1: Int32
    init(l0: Heap1, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
class Mut3 {
    var l0: Heap2
    init(l0: Heap2) {
        self.l0 = l0
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
    var v6: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v6 = Heap1(l0: v2, l1: v5)
    var v7: Int32 = 0
    v7 = 3
    var v8: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v8 = Heap2(l0: v6, l1: v7)
    var v9: Mut3 = Mut3(l0: Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0))
    v9 = Mut3(l0: v8)
    var v10: SpiralArray<Mut3> = SpiralArray<Mut3>([])
    v10 = SpiralArray<Mut3>(Array(repeating: Mut3(l0: Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)), count: Int(1)))
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
    var v17: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v17 = Heap1(l0: v13, l1: v16)
    var v18: Int32 = 0
    v18 = 2
    var v19: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v19 = Heap2(l0: v17, l1: v18)
    var v20: Mut3 = Mut3(l0: Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0))
    v20 = v10.items[Int(0)]
    v20.l0 = v19
    var v21: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)
    v21 = v20.l0
    var v22: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    var v23: Int32 = 0
    v22 = v21.l0
    v23 = v21.l1
    var v24: Heap0 = Heap0(l0: 0, l1: "")
    var v25: Heap0 = Heap0(l0: 0, l1: "")
    v24 = v22.l0
    v25 = v22.l1
    var v26: Int32 = 0
    var v27: String = ""
    v26 = v24.l0
    v27 = v24.l1
    var v28: Int32 = 0
    var v29: String = ""
    v28 = v25.l0
    v29 = v25.l1
    var v30: Bool = false
    v30 = (v26 == 7)
    var v32: Bool = false
    if (v30) {
        var v31: Bool = false
        v31 = (v27 == "hi")
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Bool = false
    if (v32) {
        var v33: Bool = false
        v33 = (v28 == 4)
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Bool = false
    if (v34) {
        var v35: Bool = false
        v35 = (v29 == "yo")
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Bool = false
    if (v36) {
        var v37: Bool = false
        v37 = (v23 == 2)
        v38 = v37
    } else {
        v38 = false
    }
    if (v38) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
