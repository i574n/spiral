import CRT
import WinSDK
class Mut0 {
    var l0: Int32
    init(l0: Int32) {
        self.l0 = l0
    }
}
func sp_method0(_ p0: Mut0) -> Mut0 {
    var v0: Mut0 = p0
    return v0
}
func spiral_main() -> Int32 {
    let v0: Mut0 = Mut0(l0: 1)
    var v1: Mut0 = Mut0(l0: 0)
    v1 = sp_method0(v0)
    v1.l0 = 7
    let v2: Int32 = v1.l0
    let v3: Bool = (v2 == 7)
    if (v3) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
