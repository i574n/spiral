import CRT
import WinSDK
func f_c0(_ v0: Float, _ v1: String) -> (Int32) -> (Float, String) {
    return { (v2: Int32) -> (Float, String) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            return ((0.0 as Float), v4)
        } else {
            return (v0, v1)
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Float = (1.5 as Float)
    let v1: String = "hi"
    let v2: (Int32) -> (Float, String) = f_c0(v0, v1)
    var v3: Float = (0.0 as Float)
    var v4: String = ""
    let spiral_tuple329 = v2(1)
    v3 = spiral_tuple329.0
    v4 = spiral_tuple329.1
    let v5: Bool = (v3 == (1.5 as Float))
    var v7: Bool = false
    if (v5) {
        let v6: Bool = (v4 == "hi")
        v7 = v6
    } else {
        v7 = false
    }
    if (v7) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
