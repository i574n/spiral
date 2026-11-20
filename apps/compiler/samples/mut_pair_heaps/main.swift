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
    init(l0: Heap0, l1: Heap0) {
        self.l0 = l0
        self.l1 = l1
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 1
    let v1: String = "no"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 2
    let v4: String = "zz"
    let v5: Heap0 = Heap0(l0: v3, l1: v4)
    var v6: Mut1 = Mut1(l0: Heap0(l0: 0, l1: ""), l1: Heap0(l0: 0, l1: ""))
    v6 = Mut1(l0: v2, l1: v5)
    let v7: Int32 = 7
    let v8: String = "hi"
    let v9: Heap0 = Heap0(l0: v7, l1: v8)
    let v10: Int32 = 4
    let v11: String = "yo"
    let v12: Heap0 = Heap0(l0: v10, l1: v11)
    v6.l0 = v9
    v6.l1 = v12
    var v13: Heap0 = Heap0(l0: 0, l1: "")
    var v14: Heap0 = Heap0(l0: 0, l1: "")
    v13 = v6.l0
    v14 = v6.l1
    var v15: Int32 = 0
    var v16: String = ""
    v15 = v13.l0
    v16 = v13.l1
    var v17: Int32 = 0
    var v18: String = ""
    v17 = v14.l0
    v18 = v14.l1
    let v19: Bool = (v15 == 7)
    var v21: Bool = false
    if (v19) {
        let v20: Bool = (v16 == "hi")
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Bool = false
    if (v21) {
        let v22: Bool = (v17 == 4)
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        let v24: Bool = (v18 == "yo")
        v25 = v24
    } else {
        v25 = false
    }
    if (v25) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
