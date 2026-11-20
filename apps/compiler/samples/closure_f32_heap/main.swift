import CRT
import WinSDK
class Heap0 {
    let l0: Float
    let l1: String
    init(l0: Float, l1: String) {
        self.l0 = l0
        self.l1 = l1
    }
}
func f_c0(_ v0: Heap0) -> (Int32) -> Heap0 {
    return { (v1: Int32) -> Heap0 in
        return v0
    }
}
func spiral_main() -> Int32 {
    let v0: Float = (1.5 as Float)
    let v1: String = "hi"
    let v2: Heap0 = Heap0(l0: v0, l1: v1)
    let v3: (Int32) -> Heap0 = f_c0(v2)
    let v4: Heap0 = v3(1)
    var v5: Float = (0.0 as Float)
    var v6: String = ""
    v5 = v4.l0
    v6 = v4.l1
    let v7: Bool = (v5 == (1.5 as Float))
    var v9: Bool = false
    if (v7) {
        let v8: Bool = (v6 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    if (v9) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
