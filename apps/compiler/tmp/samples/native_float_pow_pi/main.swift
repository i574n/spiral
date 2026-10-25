import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (2.0 as Float)
    var v1: Float = (0.0 as Float)
    v1 = (3.0 as Float)
    var v2: Double = (0.0 as Double)
    v2 = (2.0 as Double)
    var v3: Double = (0.0 as Double)
    v3 = (3.0 as Double)
    var v4: Float = (0.0 as Float)
    v4 = (3.1415927 as Float)
    var v5: Double = (0.0 as Double)
    v5 = (3.141592653589793 as Double)
    var v6: Float = (0.0 as Float)
    v6 = powf(v0, v1)
    var v7: Bool = false
    v7 = (v6 == (8.0 as Float))
    var v10: Bool = false
    if (v7) {
        var v8: Double = (0.0 as Double)
        v8 = pow(v2, v3)
        var v9: Bool = false
        v9 = (v8 == (8.0 as Double))
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Bool = false
    if (v10) {
        var v11: Bool = false
        v11 = (v4 > (3.0 as Float))
        v12 = v11
    } else {
        v12 = false
    }
    var v14: Bool = false
    if (v12) {
        var v13: Bool = false
        v13 = (v4 < (4.0 as Float))
        v14 = v13
    } else {
        v14 = false
    }
    var v16: Bool = false
    if (v14) {
        var v15: Bool = false
        v15 = (v5 > (3.0 as Double))
        v16 = v15
    } else {
        v16 = false
    }
    var v18: Bool = false
    if (v16) {
        var v17: Bool = false
        v17 = (v5 < (4.0 as Double))
        v18 = v17
    } else {
        v18 = false
    }
    if (v18) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
