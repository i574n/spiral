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
func spiral_main() -> Int32 {
    let v0: Int32 = 3
    let v1: String = "no"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 1
    let v4: Heap1 = Heap1(l0: v2, l1: v3)
    var v5: Mut2 = Mut2(l0: Heap1(l0: Heap0(l0: 0, l1: ""), l1: 0))
    v5 = Mut2(l0: v4)
    let v6: Int32 = 7
    let v7: String = "hi"
    let v8: Heap0 = Heap0(l0: v6, l1: v7)
    let v9: Int32 = 4
    let v10: Heap1 = Heap1(l0: v8, l1: v9)
    v5.l0 = v10
    let v11: Heap1 = v5.l0
    var v12: Heap0 = Heap0(l0: 0, l1: "")
    var v13: Int32 = 0
    v12 = v11.l0
    v13 = v11.l1
    var v14: Int32 = 0
    var v15: String = ""
    v14 = v12.l0
    v15 = v12.l1
    let v16: Bool = (v14 == 7)
    var v18: Bool = false
    if (v16) {
        let v17: Bool = (v15 == "hi")
        v18 = v17
    } else {
        v18 = false
    }
    var v20: Bool = false
    if (v18) {
        let v19: Bool = (v13 == 4)
        v20 = v19
    } else {
        v20 = false
    }
    if (v20) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
