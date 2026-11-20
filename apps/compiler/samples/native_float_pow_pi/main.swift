import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Float = (2.0 as Float)
    let v1: Float = (3.0 as Float)
    let v2: Double = (2.0 as Double)
    let v3: Double = (3.0 as Double)
    let v4: Float = (3.1415927 as Float)
    let v5: Double = (3.141592653589793 as Double)
    let v6: Float = powf(v0, v1)
    let v7: Bool = (v6 == (8.0 as Float))
    var v10: Bool = false
    if (v7) {
        let v8: Double = pow(v2, v3)
        let v9: Bool = (v8 == (8.0 as Double))
        v10 = v9
    } else {
        v10 = false
    }
    var v12: Bool = false
    if (v10) {
        let v11: Bool = (v4 > (3.0 as Float))
        v12 = v11
    } else {
        v12 = false
    }
    var v14: Bool = false
    if (v12) {
        let v13: Bool = (v4 < (4.0 as Float))
        v14 = v13
    } else {
        v14 = false
    }
    var v16: Bool = false
    if (v14) {
        let v15: Bool = (v5 > (3.0 as Double))
        v16 = v15
    } else {
        v16 = false
    }
    var v18: Bool = false
    if (v16) {
        let v17: Bool = (v5 < (4.0 as Double))
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
