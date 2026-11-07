import CRT
import WinSDK
func f_c0(_ v0: String, _ v1: String) -> (Int32) -> (String, String) {
    return { (v2: Int32) -> (String, String) in
        var v3: Bool = false
        v3 = (v2 == 0)
        if (v3) {
            var v4: String = ""
            v4 = "no"
            var v5: String = ""
            v5 = "nay"
            return (v4, v5)
        } else {
            return (v0, v1)
        }
    }
}
func spiral_main() -> Int32 {
    let v0: String = "hi"
    let v1: String = "yo"
    let v2: (Int32) -> (String, String) = f_c0(v0, v1)
    var v3: String = ""
    var v4: String = ""
    let spiral_tuple290 = v2(1)
    v3 = spiral_tuple290.0
    v4 = spiral_tuple290.1
    var v5: Bool = false
    v5 = (v3 == "hi")
    var v7: Bool = false
    if (v5) {
        let v6: Bool = (v4 == "yo")
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
