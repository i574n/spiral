import CRT
import WinSDK
func sp_target_global_0(_ p0: String) {
    var v0: String = p0
}
func spiral_main() -> Int32 {
    var v0: String = ""
    v0 = "SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_pos-p_B64:Ly9Q"
    sp_target_global_0(v0)
    sp_target_global_0(v0)
    var v1: String = ""
    v1 = "SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_pos-b_B64:Ly9C"
    sp_target_global_0(v1)
    var v2: String = ""
    v2 = "SPIRAL_TARGET_GLOBAL_RUST_AFTER_MAIN_test-item_B64:Zm4gc3BpcmFsX2F0dHJpYnV0ZV9zbW9rZSgpIHsKICAgIGFzc2VydF9lcSEoNiAqIDcsIDQyKTsKfQo="
    sp_target_global_0(v2)
    var v3: String = ""
    v3 = "SPIRAL_ITEM_METADATA_TEST_test-item"
    sp_target_global_0(v3)
    var v4: String = ""
    v4 = "SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_pos-p_B64:Ly9Q"
    sp_target_global_0(v4)
    sp_target_global_0(v4)
    var v5: String = ""
    v5 = "SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_pos-b_B64:Ly9C"
    sp_target_global_0(v5)
    var v6: String = ""
    v6 = "SPIRAL_TARGET_GLOBAL_DELPHI_AFTER_MAIN_test-item_B64:cHJvY2VkdXJlIFNwaXJhbFRhcmdldEdsb2JhbFNtb2tlOwpiZWdpbgogIGlmIDYgKiA3IDw+IDQyIHRoZW4gSGFsdCgxKTsKZW5kOwo="
    sp_target_global_0(v6)
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
