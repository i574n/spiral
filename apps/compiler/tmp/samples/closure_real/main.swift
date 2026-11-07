import CRT
import WinSDK
func f_c0(_ v0: Double) -> (Int32) -> Double {
    return { (v1: Int32) -> Double in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            return (0.0 as Double)
        } else {
            return v0
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Double = (1.5 as Double)
    let v1: (Int32) -> Double = f_c0(v0)
    var v2: Double = (0.0 as Double)
    v2 = v1(1)
    let v3: Bool = (v2 == (1.5 as Double))
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
