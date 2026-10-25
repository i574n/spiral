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
class Heap2 {
    let l0: Heap1
    let l1: Int32
    init(l0: Heap1, l1: Int32) {
        self.l0 = l0
        self.l1 = l1
    }
}
func f_c0(_ v0: Heap2) -> (Int32) -> Heap2 {
    return { (v1: Int32) -> Heap2 in
        return v0
    }
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 7
    var v1: String = ""
    v1 = "hi"
    var v2: Heap0 = Heap0(l0: 0, l1: "")
    v2 = Heap0(l0: v0, l1: v1)
    var v3: Int32 = 0
    v3 = 1
    var v4: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    v4 = Heap1(l0: v2, l1: v3)
    var v5: Int32 = 0
    v5 = 2
    var v6: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0), l1: 0)
    v6 = Heap2(l0: v4, l1: v5)
    var v7: (Int32) -> Heap2 = { (_: Int32) -> Heap2 in fatalError("unreachable closure") }
    v7 = f_c0(v6)
    var v8: Heap2 = Heap2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0), l1: 0)
    v8 = v7(1)
    var v9: Heap1 = Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0)
    var v10: Int32 = 0
    v9 = v8.l0
    v10 = v8.l1
    var v11: Heap0 = Heap0(l0: 0, l1: "")
    var v12: Int32 = 0
    v11 = v9.l0
    v12 = v9.l1
    var v13: Int32 = 0
    var v14: String = ""
    v13 = v11.l0
    v14 = v11.l1
    var v15: Bool = false
    v15 = (v13 == 7)
    var v17: Bool = false
    if (v15) {
        var v16: Bool = false
        v16 = (v14 == "hi")
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Bool = false
    if (v17) {
        var v18: Bool = false
        v18 = (v12 == 1)
        v19 = v18
    } else {
        v19 = false
    }
    var v21: Bool = false
    if (v19) {
        var v20: Bool = false
        v20 = (v10 == 2)
        v21 = v20
    } else {
        v21 = false
    }
    if (v21) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
