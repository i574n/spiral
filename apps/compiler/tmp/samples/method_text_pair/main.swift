import CRT
import WinSDK
func sp_method0(_ p0: String, _ p1: String) -> (String, String) {
    var v0: String = p0
    var v1: String = p1
    var v2: Bool = false
    v2 = (v0 == "")
    if (v2) {
        var v3: String = ""
        v3 = "no"
        var v4: String = ""
        v4 = "nay"
        return (v3, v4)
    } else {
        return (v0, v1)
    }
}
func spiral_main() -> Int32 {
    let v0: String = "hi"
    let v1: String = "yo"
    var v2: String = ""
    var v3: String = ""
    let spiral_tuple161 = sp_method0(v0, v1)
    v2 = spiral_tuple161.0
    v3 = spiral_tuple161.1
    var v4: Bool = false
    v4 = (v2 == "hi")
    var v6: Bool = false
    if (v4) {
        let v5: Bool = (v3 == "yo")
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
