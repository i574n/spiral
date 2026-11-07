import CRT
import WinSDK
class Mut0 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func f_c0(_ v0: Mut0) -> (Int32) -> Mut0 {
    return { (v1: Int32) -> Mut0 in
        return v0
    }
}
func spiral_main() -> Int32 {
    let v0: Mut0 = Mut0(l0: 1)
    let v1: (Int32) -> Mut0 = f_c0(v0)
    var v2: Mut0 = Mut0(l0: 0)
    v2 = v1(1)
    v2.l0 = 7
    let v3: Int32 = v2.l0
    let v4: Bool = (v3 == 7)
    if (v4) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
