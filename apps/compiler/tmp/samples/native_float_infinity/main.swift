import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: Float = Float.infinity
    let v1: Double = Double.infinity
    let v2: Float = (-(v0))
    let v3: Double = (-(v1))
    let v4: Float = (1.0 as Float)
    let v5: Double = (1.0 as Double)
    let v6: Bool = (v4.isNaN)
    var v8: Bool = false
    if (v6) {
        v8 = true
    } else {
        let v7: Bool = (v5.isNaN)
        v8 = v7
    }
    if (v8) {
        return 3
    } else {
        let v9: Bool = (v0 > v4)
        var v11: Bool = false
        if (v9) {
            let v10: Bool = (v1 > v5)
            v11 = v10
        } else {
            v11 = false
        }
        if (v11) {
            let v12: Bool = (v2 < (0.0 as Float))
            var v14: Bool = false
            if (v12) {
                let v13: Bool = (v3 < (0.0 as Double))
                v14 = v13
            } else {
                v14 = false
            }
            if (v14) {
                return 0
            } else {
                return 2
            }
        } else {
            return 1
        }
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
