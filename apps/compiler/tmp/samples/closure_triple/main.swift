import CRT
import WinSDK
func f_c0(_ v0: Int32, _ v1: String, _ v2: Bool) -> (Int32) -> (Int32, String, Bool) {
    return { (v3: Int32) -> (Int32, String, Bool) in
        var v4: Bool = false
        v4 = (v3 == 0)
        if (v4) {
            var v5: String = ""
            v5 = "no"
            return (0, v5, false)
        } else {
            return (v0, v1, v2)
        }
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    let v1: String = "hi"
    let v2: Bool = true
    let v3: (Int32) -> (Int32, String, Bool) = f_c0(v0, v1, v2)
    var v4: Int32 = 0
    var v5: String = ""
    var v6: Bool = false
    let spiral_tuple373 = v3(1)
    v4 = spiral_tuple373.0
    v5 = spiral_tuple373.1
    v6 = spiral_tuple373.2
    let v7: Bool = (v4 == 7)
    var v9: Bool = false
    if (v7) {
        let v8: Bool = (v5 == "hi")
        v9 = v8
    } else {
        v9 = false
    }
    let v10: Bool = (v9 && v6)
    if (v10) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
