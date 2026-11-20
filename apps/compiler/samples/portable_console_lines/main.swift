import CRT
import WinSDK
func spiral_main() -> Int32 {
    let v0: String = "hello"
    print(v0)
    let v1: Int32 = 42
    print(v1)
    let v2: String = "a"
    print(v2, terminator: "")
    let v3: String = "b"
    print(v3, terminator: "")
    let v4: String = ""
    print(v4)
    let v5: Int64 = (-7 as Int64)
    print(v5)
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
