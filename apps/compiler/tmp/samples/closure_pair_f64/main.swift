import CRT
import WinSDK
func f_c0(_ v0: Double) -> (Int32) -> (Double, Double) {
    return { (v1: Int32) -> (Double, Double) in
        var v2: Bool = false
        v2 = (v1 == 0)
        if (v2) {
            return ((0.0 as Double), (0.0 as Double))
        } else {
            return (v0, (2.5 as Double))
        }
    }
}
func spiral_main() -> Int32 {
    var v0: Double = (0.0 as Double)
    v0 = (1.5 as Double)
    var v1: (Int32) -> (Double, Double) = { (_: Int32) -> (Double, Double) in fatalError("unreachable closure") }
    v1 = f_c0(v0)
    var v2: Double = (0.0 as Double)
    var v3: Double = (0.0 as Double)
    let spiral_tuple305 = v1(1)
    v2 = spiral_tuple305.0
    v3 = spiral_tuple305.1
    var v4: Bool = false
    v4 = (v2 == (1.5 as Double))
    var v6: Bool = false
    if (v4) {
        var v5: Bool = false
        v5 = (v3 == (2.5 as Double))
        v6 = v5
    } else {
        v6 = false
    }
    if (v6) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
