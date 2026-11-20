import CRT
import WinSDK
func sp_method0(_ p0: Int32) -> (String, String) {
    var v0: Int32 = p0
    var v1: Bool = false
    v1 = (v0 == 0)
    if (v1) {
        var v2: String = ""
        v2 = "no"
        return (v2, v2)
    } else {
        var v3: String = ""
        v3 = "hi"
        var v4: String = ""
        v4 = "yo"
        return (v3, v4)
    }
}
func spiral_main() -> Int32 {
    let v0: Int32 = 7
    var v1: String = ""
    var v2: String = ""
    let spiral_tuple111 = sp_method0(v0)
    v1 = spiral_tuple111.0
    v2 = spiral_tuple111.1
    var v3: Bool = false
    v3 = (v1 == "hi")
    var v5: Bool = false
    if (v3) {
        var v4: Bool = false
        v4 = (v2 == "yo")
        v5 = v4
    } else {
        v5 = false
    }
    if (v5) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
