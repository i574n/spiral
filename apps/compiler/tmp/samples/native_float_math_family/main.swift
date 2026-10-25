import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Float = (0.0 as Float)
    let v1: Float = (1.0 as Float)
    let v2: Double = (0.0 as Double)
    let v3: Double = (1.0 as Double)
    let v4: Float = logf(v1)
    let v5: Bool = (v4 == v0)
    var v8: Bool = false
    if (v5) {
        let v6: Double = log(v3)
        let v7: Bool = (v6 == v2)
        v8 = v7
    } else {
        v8 = false
    }
    var v11: Bool = false
    if (v8) {
        let v9: Float = expf(v0)
        let v10: Bool = (v9 == v1)
        v11 = v10
    } else {
        v11 = false
    }
    var v14: Bool = false
    if (v11) {
        let v12: Double = exp(v2)
        let v13: Bool = (v12 == v3)
        v14 = v13
    } else {
        v14 = false
    }
    var v17: Bool = false
    if (v14) {
        let v15: Float = tanhf(v0)
        let v16: Bool = (v15 == v0)
        v17 = v16
    } else {
        v17 = false
    }
    var v20: Bool = false
    if (v17) {
        let v18: Double = tanh(v2)
        let v19: Bool = (v18 == v2)
        v20 = v19
    } else {
        v20 = false
    }
    var v23: Bool = false
    if (v20) {
        let v21: Float = sinf(v0)
        let v22: Bool = (v21 == v0)
        v23 = v22
    } else {
        v23 = false
    }
    var v26: Bool = false
    if (v23) {
        let v24: Double = sin(v2)
        let v25: Bool = (v24 == v2)
        v26 = v25
    } else {
        v26 = false
    }
    var v29: Bool = false
    if (v26) {
        let v27: Float = cosf(v0)
        let v28: Bool = (v27 == v1)
        v29 = v28
    } else {
        v29 = false
    }
    var v32: Bool = false
    if (v29) {
        let v30: Double = cos(v2)
        let v31: Bool = (v30 == v3)
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
