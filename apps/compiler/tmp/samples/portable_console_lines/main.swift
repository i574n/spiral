import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "hello"
    print(v0)
    var v1: Int32 = 0
    v1 = 42
    print(v1)
    var v2: String = ""
    v2 = "a"
    print(v2, terminator: "")
    var v3: String = ""
    v3 = "b"
    print(v3, terminator: "")
    var v4: String = ""
    v4 = ""
    print(v4)
    var v5: Int64 = (0 as Int64)
    v5 = (-7 as Int64)
    print(v5)
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
