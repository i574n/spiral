import CRT
import WinSDK
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 60
    var v1: Int64 = (0 as Int64)
    v1 = (-9000000000 as Int64)
    var v2: UInt8 = UInt8(0)
    v2 = UInt8(200)
    var v3: String = ""
    v3 = "cube"
    _ = fputs(v3 + ": " + String(v0) + " frames, checksum " + String(970392) + "\n", stdout)
    _ = fputs("big " + String(v1) + ", small " + String(-5) + ", byte " + String(v2) + "\n", stdout)
    _ = fputs("100% {braces} \"quoted\" \\ tab\tend\n", stdout)
    _ = fputs("literal" + "\n", stdout)
    _ = fputs(v3, stdout)
    _ = fputs("\n", stdout)
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
