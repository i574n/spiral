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
func f_c0(_ v0: Heap0, _ v1: Heap0) -> (Int32) -> (Heap0, Heap0) {
    return { (v2: Int32) -> (Heap0, Heap0) in
        return (v0, v1)
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: String = "hi"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: Int32 = 4
    let v4: String = "yo"
    let v5: Heap0 = Heap0(l0: v3, l1: v4)
    let v6: (Int32) -> (Heap0, Heap0) = f_c0(v2, v5)
    var v7: Heap0 = Heap0(l0: 0, l1: "")
    var v8: Heap0 = Heap0(l0: 0, l1: "")
    let spiral_tuple530 = v6(1)
    v7 = spiral_tuple530.0
    v8 = spiral_tuple530.1
    var v9: Int32 = 0
    var v10: String = ""
    v9 = v7.l0
    v10 = v7.l1
    var v11: Int32 = 0
    var v12: String = ""
    v11 = v8.l0
    v12 = v8.l1
    let v13: Bool = (v9 == 7)
    var v15: Bool = false
    if (v13) {
        let v14: Bool = (v10 == "hi")
        v15 = v14
    } else {
        v15 = false
    }
    var v17: Bool = false
    if (v15) {
        let v16: Bool = (v11 == 4)
        v17 = v16
    } else {
        v17 = false
    }
    var v19: Bool = false
    if (v17) {
        let v18: Bool = (v12 == "yo")
        v19 = v18
    } else {
        v19 = false
    }
    if (v19) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
