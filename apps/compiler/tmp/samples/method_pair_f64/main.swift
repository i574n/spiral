import CRT
import WinSDK
func sp_method0(_ p0: Int32) -> (Double, Double) {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        return ((0.0 as Double), (0.0 as Double))
    } else {
        return ((1.5 as Double), (2.5 as Double))
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    var v1: Double = (0.0 as Double)
    var v2: Double = (0.0 as Double)
    let spiral_tuple142 = sp_method0(v0)
    v1 = spiral_tuple142.0
    v2 = spiral_tuple142.1
    let v3: Bool = (v1 == (1.5 as Double))
    var v5: Bool = false
    if (v3) {
        let v4: Bool = (v2 == (2.5 as Double))
        v5 = v4
    } else {
        v5 = false
    }
    if (v5) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
