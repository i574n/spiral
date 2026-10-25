import CRT
import WinSDK
func sp_target_global_0(_ p0: String) {
    var v0: String = p0
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_same_B64:Ly9Q"
    sp_target_global_0(v0)
    var v1: String = ""
    v1 = "SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_same_B64:Ly9C"
    sp_target_global_0(v1)
    var v2: String = ""
    v2 = "SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_same_B64:Ly9Q"
    sp_target_global_0(v2)
    var v3: String = ""
    v3 = "SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_same_B64:Ly9C"
    sp_target_global_0(v3)
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
