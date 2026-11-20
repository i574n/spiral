import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Double = (1.5 as Double)
    let v1: Double = (-2.0 as Double)
    let v2: Double = (v0 / v1)
    let v3: Double = (1000000.0 as Double)
    let v4: Double = (v3 * v3)
    let v5: Double = (v4 * v3)
    let v6: Double = (v5 * (10000.0 as Double))
    let v7: Double = (v6 * v6)
    let v8: Int32 = 3
    let v9: Double = Double(v8)
    let v10: Double = (2.9 as Double)
    let v11: Double = (-1.9 as Double)
    let v12: Int32 = Int32(v10)
    let v13: Int32 = Int32(v11)
    let v14: Float = (1.5 as Float)
    let v15: Double = Double(v14)
    let v16: Bool = (v2 == (-0.75 as Double))
    var v18: Bool = false
    if (v16) {
        let v17: Bool = (v7 > v6)
        v18 = v17
    } else {
        v18 = false
    }
    var v21: Bool = false
    if (v18) {
        let v19: Double = (v7 * v6)
        let v20: Bool = (v7 < v19)
        v21 = v20
    } else {
        v21 = false
    }
    var v23: Bool = false
    if (v21) {
        let v22: Bool = (v9 == (3.0 as Double))
        v23 = v22
    } else {
        v23 = false
    }
    var v25: Bool = false
    if (v23) {
        let v24: Bool = (v12 == 2)
        v25 = v24
    } else {
        v25 = false
    }
    var v27: Bool = false
    if (v25) {
        let v26: Bool = (v13 == -1)
        v27 = v26
    } else {
        v27 = false
    }
    var v29: Bool = false
    if (v27) {
        let v28: Bool = (v15 == (1.5 as Double))
        v29 = v28
    } else {
        v29 = false
    }
    if (v29) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
