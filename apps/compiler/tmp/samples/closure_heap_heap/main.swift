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
func f_c0(_ v0: Heap1) -> (Int32) -> Heap1 {
    return { (v1: Int32) -> Heap1 in
        return v0
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: String = "hi"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 1
    let v4: Heap1 = Heap1(l0: v2, l1: v3)
    let v5: (Int32) -> Heap1 = f_c0(v4)
    let v6: Heap1 = v5(1)
    var v7: Heap0 = Heap0(l0: 0, l1: "")
    var v8: Int32 = 0
    v7 = v6.l0
    v8 = v6.l1
    var v9: Int32 = 0
    var v10: String = ""
    v9 = v7.l0
    v10 = v7.l1
    let v11: Bool = (v9 == 7)
    var v13: Bool = false
    if (v11) {
        let v12: Bool = (v10 == "hi")
        v13 = v12
    } else {
        v13 = false
    }
    var v15: Bool = false
    if (v13) {
        let v14: Bool = (v8 == 1)
        v15 = v14
    } else {
        v15 = false
    }
    if (v15) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
