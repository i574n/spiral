import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Float = (0.0 as Float)
    v0 = (0.0 as Float)
    var v1: Float = (0.0 as Float)
    v1 = (1.0 as Float)
    var v2: Double = (0.0 as Double)
    v2 = (0.0 as Double)
    var v3: Double = (0.0 as Double)
    v3 = (1.0 as Double)
    var v4: Float = (0.0 as Float)
    v4 = logf(v1)
    var v5: Bool = false
    v5 = (v4 == v0)
    var v8: Bool = false
    if (v5) {
        var v6: Double = (0.0 as Double)
        v6 = log(v3)
        var v7: Bool = false
        v7 = (v6 == v2)
        v8 = v7
    } else {
        v8 = false
    }
    var v11: Bool = false
    if (v8) {
        var v9: Float = (0.0 as Float)
        v9 = expf(v0)
        var v10: Bool = false
        v10 = (v9 == v1)
        v11 = v10
    } else {
        v11 = false
    }
    var v14: Bool = false
    if (v11) {
        var v12: Double = (0.0 as Double)
        v12 = exp(v2)
        var v13: Bool = false
        v13 = (v12 == v3)
        v14 = v13
    } else {
        v14 = false
    }
    var v17: Bool = false
    if (v14) {
        var v15: Float = (0.0 as Float)
        v15 = tanhf(v0)
        var v16: Bool = false
        v16 = (v15 == v0)
        v17 = v16
    } else {
        v17 = false
    }
    var v20: Bool = false
    if (v17) {
        var v18: Double = (0.0 as Double)
        v18 = tanh(v2)
        var v19: Bool = false
        v19 = (v18 == v2)
        v20 = v19
    } else {
        v20 = false
    }
    var v23: Bool = false
    if (v20) {
        var v21: Float = (0.0 as Float)
        v21 = sinf(v0)
        var v22: Bool = false
        v22 = (v21 == v0)
        v23 = v22
    } else {
        v23 = false
    }
    var v26: Bool = false
    if (v23) {
        var v24: Double = (0.0 as Double)
        v24 = sin(v2)
        var v25: Bool = false
        v25 = (v24 == v2)
        v26 = v25
    } else {
        v26 = false
    }
    var v29: Bool = false
    if (v26) {
        var v27: Float = (0.0 as Float)
        v27 = cosf(v0)
        var v28: Bool = false
        v28 = (v27 == v1)
        v29 = v28
    } else {
        v29 = false
    }
    var v32: Bool = false
    if (v29) {
        var v30: Double = (0.0 as Double)
        v30 = cos(v2)
        var v31: Bool = false
        v31 = (v30 == v3)
        v32 = v31
    } else {
        v32 = false
    }
    if (v32) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
