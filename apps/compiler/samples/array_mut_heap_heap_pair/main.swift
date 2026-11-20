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
    let v0: Int32 = 1
    let v1: String = "no"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 2
    let v4: String = "zz"
    let v5: Heap0 = Heap0(l0: v3, l1: v4)
    let v6: Heap1 = Heap1(l0: v2, l1: v5)
    let v7: Int32 = 3
    let v8: Heap2 = Heap2(l0: v6, l1: v7)
    let v9: Mut3 = Mut3(l0: v8)
    var v10: SpiralArray<Mut3> = SpiralArray<Mut3>([])
    v10 = SpiralArray<Mut3>(Array(repeating: Mut3(l0: Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0)), count: Int(1)))
    v10.items[Int(0)] = v9
    let v11: Int32 = 7
    let v12: String = "hi"
    let v13: Heap0 = Heap0(l0: v11, l1: v12)
    let v14: Int32 = 4
    let v15: String = "yo"
    let v16: Heap0 = Heap0(l0: v14, l1: v15)
    let v17: Heap1 = Heap1(l0: v13, l1: v16)
    let v18: Int32 = 2
    let v19: Heap2 = Heap2(l0: v17, l1: v18)
    var v20: Mut3 = Mut3(l0: Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: "")), l1: 0))
    v20 = v10.items[Int(0)]
    v20.l0 = v19
    let v21: Heap2 = v20.l0
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
    let v30: Bool = (v26 == 7)
    var v32: Bool = false
    if (v30) {
        let v31: Bool = (v27 == "hi")
        v32 = v31
    } else {
        v32 = false
    }
    var v34: Bool = false
    if (v32) {
        let v33: Bool = (v28 == 4)
        v34 = v33
    } else {
        v34 = false
    }
    var v36: Bool = false
    if (v34) {
        let v35: Bool = (v29 == "yo")
        v36 = v35
    } else {
        v36 = false
    }
    var v38: Bool = false
    if (v36) {
        let v37: Bool = (v23 == 2)
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
